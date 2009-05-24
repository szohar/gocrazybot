//-- This program makes the LED at P1.6 blink at different
// speeds (SerialComm.C)
//-- Uses Timer 3 and interrupts for the blinking frequency
//-- Uses the external crystal oscillator 22.11845 MHz
//-- Receives commands from PC to change the blinking speed
//-- Timer 1 is used to generate Baud rate for UART0
#include <c8051f020.h>
#include <stdio.h>
#include <stdlib.h>


//--------------------------------------------------------------
// 16-bit SFR Definitions for 'F02x
//--------------------------------------------------------------
sfr16 TMR3RL = 0x92; // Timer3 reload value
sfr16 TMR3 = 0x94; // Timer3 counter
//--------------------------------------------------------------// Global CONSTANTS
//--------------------------------------------------------------
#define BLINKCLK 2000000
sbit LED = P1^6;
sbit DIR = P1^0;
unsigned char LED_count;
unsigned char blink_speed;
unsigned int received_byte;
unsigned int sent_byte;
unsigned int command;
unsigned int message;
unsigned int port5;
unsigned int outBuffer[4];
unsigned int RPM = 0x00;
unsigned int pulses;
unsigned int actual_speed;
int time_in_sec;
int i, count, random;
int Tick_count = 0x00;

unsigned short new_cmd_received; //-- set each time new
unsigned short new_cmd_sent;
int transmitFlag;
int prevTransmitFlag;


//-- function prototypes 
void Init_Port(void); 	//-- Configures the Crossbar and GPIO
						// ports
void Init_UART0(void); 	//-- configure and initialize the UART0
						// serial comm
void Init_Timer3(unsigned int counts);
void Timer3_ISR(void); //-- ISR for Timer 3
void UART0_ISR(void); //-- ISR for UART0
void Init_ADC0		(void);			//-- Initialise the ADC0
void ADC0_ISR       (void);
void INT1_ISR		(void);

//--------------------------------------------------------------

#define LCD_DAT_PORT  P6		  // LCD is in 8 bit mode
#define LCD_CTRL_PORT P7		  // 3 control pins on P7
#define RS_MASK       0x01		  // for assessing LCD_CTRL_PORT
#define RW_MASK       0x02
#define E_MASK        0x04

//---------------------------------------------------------------------------------
// Global MACROS
//---------------------------------------------------------------------------------
#define pulse_E();\
	small_delay(1);\
	LCD_CTRL_PORT = LCD_CTRL_PORT | E_MASK;\
	small_delay(1);\
	LCD_CTRL_PORT = LCD_CTRL_PORT & ~E_MASK;\

//---------------------------------------------------------------------------------


//-- LCD related functions ----------
void lcd_init       (void);          // initialize the lcd to 8 bit mode
void lcd_busy_wait  (void);          // wait until the lcd is no longer busy
char putchar        (char c);        // replaces standard function and uses LCD
void lcd_cmd        (char cmd);      // write a command to the lcd controller
void lcd_home       (void);          // home curser
void lcd_clear      (void);          // clear display
void lcd_goto       (char addr);    // move to address addr
void lcd_move_curser(char dist);     // moves curser forward or back by dist
void lcd_curser     (bit on);        // 1 displays curser, 0 hides it
void lcd_puts       (char string[]); // send string to lcd at current curser loc
void small_delay    (char d);   // 8 bit,  about 0.34us per count @22.1MHz
void large_delay    (char d);   // 16 bit, about 82us   per count @22.1MHz
void huge_delay     (char d);   // 24 bit, about 22ms   per count @22.1MHz



void Init_Clock(void)
{
		OSCXCN = 0x67; //-- 0110 0111b
		//-- External Osc Freq Control Bits (XFCN2-0) set to 111
		// because crystal frequency > 6.7 MHz
		//-- Crystal Oscillator Mode (XOSCMD2-0) set to 110
		//-- wait till XTLVLD pin is set
		while ( !(OSCXCN & 0x80) );
		OSCICN = 0x88; //-- 1000 1000b
		//-- Bit 2 : Internal Osc. disabled (IOSCEN = 0)
		//-- Bit 3 : Uses External Oscillator as System Clock
		// (CLKSL = 1)
		//-- Bit 7 : Missing Clock Detector Enabled (MSCLKE = 1)
}

void Init_Port(void) //-- Configures the Crossbar & GPIO ports
{
		XBR0 = 0x04; //-- Enable UART0
		XBR1 = 0x04;
		XBR1 |= 0x10;	//-- enable /INT1 (Pin P0.3)  //--New
		XBR2 = 0x40; //-- Enable Crossbar and weak pull-ups
		// (globally)
		P0MDOUT |= 0x01; //-- Enable TX0 as a push-pull o/p
		P1MDOUT = 0xff; //-- Enable P1.6 (LED) as push-
						 // pull output
				
				//-- Port 7-4 I/O Lines
		P74OUT = 0x48;				// Output configuration for P4-7
									// (P7[0:3] Push Pull) - Control Lines for LCD
								// (P6 Open-Drain)- Data Lines for LCD
								// (P5[7:4] Push Pull) - 4 LEDs
								// (P5[3:0] Open Drain) - 4 Push-Button Switches (input)
								// (P4 Open Drain) - 8 DIP Switches (input)


		P5 |= 0x0F;


	ES0 = 1;	//-- enable UART0 interrupt
	IT0 = 1;	//-- /INT0 is edge triggered
	IT1 = 1;	//-- /INT1 is edge triggered
	PT0 =1;		//-- High priority for Timer 0 (PWM generator)
	PT1 =1;		//-- High priority for Timer 1 (Tacho Counter)
	PT2 =1;
	EX0 = 1;	//-- enable external interrupt 0 (/INT0)
	EX1 = 1;	//-- enable external interrupt 1 (/INT1)
	

}
//--------------------------------------------------------------
void Init_UART0(void)
{
	//-- set up Timer 1 to generate the baude rate (115200) // for UART0
	CKCON |= 0x10; //-- T1M=1; Timer 1 uses the system clock
	// 22.11845 MHz
	TMOD = 0x20; //-- Timer 1 in Mode 2 (8-bit auto-
	// reload)
	TH1 = 0xF4; //-- Baud rate = 115200
	TR1 = 1; //-- start Timer 1 (TCON.6 = 1)
	T2CON &= 0xCF; //-- Timer 1 overflows used for receive & // transmit clock (RCLK0=0, TCLK0=0)
	//-- Set up the UART0
	PCON |= 0x80; //-- SMOD0=1 (UART0 baud rate divide-by-2
	// disabled)
	SCON0 = 0x50; //-- UART0 Mode 1, Logic level of stop
	
	// bit ignored and Receive enabled
	//-- enable UART0 interrupt
	IE |= 0x10;
	IP |= 0x10; //-- set to high priority level
	RI0= 0; //-- clear the receive interrupt flag;

	// ready to receive more
}
//--------------------------------------------------------------
//-- Configure Timer3 to auto-reload and generate an interrupt 
// at interval specified by <counts> using SYSCLK/12 as its
// time base.
void Init_Timer3 (unsigned int counts)
{
		TMR3CN = 0x00; //-- Stop Timer3; Clear TF3;
					   //-- use SYSCLK/12 as time base
		TMR3RL = -counts; //-- Init reload values
		TMR3 = 0xffff; //-- set to reload immediately
		EIE2 |= 0x01; //-- enable Timer3 interrupts
		TMR3CN |= 0x04; //-- start Timer3 by setting TR3
		// (TMR3CN.2) to 1
}

//-- This routine changes the state of the LED whenever Timer3
// overflows.
void Timer3_ISR (void) interrupt 14
{
		TMR3CN &= ~(0x80); //-- clear TF3
		LED_count++;
		Tick_count++;
		
		
			
			
			if ( (LED_count % 10) == 0) //-- do every 10th count
			{
				if ( blink_speed==0)
				{
					LED=0;
				}

				else
				{
			   
				LED = ~LED; //-- change state of LED
				LED_count = 0;
				}
			}
		
}



void Init_ADC0(void)
{
    	
    REF0CN = 0x03;	// Vref setup
    ADC0CF = 0x80;	// SAR0 Conversion, clock = 941 kHz approx, Gain = 1

    AMX0CF = 0x00;	// 8 single-ended inputs
    AMX0SL = 0x00;	// select AIN0 input
    ADC0CN = 0x80;	// enable ADC0, continuous tracking mode, 
					// conversion initiated on every write of "1" to AD0BUSY
					// and right justify data

    EIE2 = 0x02;	// enable ADC0 end of conversion interrupts

}


void ADC0_ISR(void) interrupt 15
{
  
    ADC0CN = 0x91;	// enable ADC0, continuous tracking mode, ADC0 conversion is in progress 
					// conversion initiated on every write of "1" to AD0BUSY
					// and left justify data

	 //message = ADC0H;	// calc the ref_speed by using ADCO value
	 //message = message >>1; //make message to between 0 and 127


}


//--------------------------------------------------------------
void UART0_ISR(void) interrupt 4
{
	
	time_in_sec=1/115000;

		//-- pending flags RI0 (SCON0.0) and TI0(SCON0.1)
		if  ( RI0 == 1) //-- interrupt caused by received byte
		{

			received_byte = SBUF0; //-- read the input buffer
			RI0 = 0; //-- clear the flag
			new_cmd_received=1;
        
		}
      

             //START: buttons 1 and 2 together

			  if  ( P5 == 0x03) 
				  {
				      
                    	lcd_clear();
			         //	lcd_goto(0x00) ;   //-- go to first Row
					    printf("   Start   ");
						//lcd_goto(0x40);   //-- go to Second Row
						printf("  but 2 & 3:  ");


					   //start
						command = 0xCC; // DEC=204
				  }

        
		 //STALL: buttons 3 and 4 together

          if ( (P5 == 0x0C)) 
				  {
				      
                    	lcd_clear();
			         //	lcd_goto(0x00) ;   //-- go to first Row
					    printf("   Stall   ");
					//	lcd_goto(0x40);   //-- go to Second Row
						printf(" but 3 & 4   ");

						P5 &= 0x0F;

					   //stall
						command = 0xDD;
				  }

		 random = rand();
		 
		 random = random >> 8;

       //set output buffer
            outBuffer[0] = command;
		
	    	outBuffer[1] = P2;
			outBuffer[2] = message;
			outBuffer[3] = received_byte;
	
		
	        for (count = 0; count <4 ; count++)
			 {

			  while(	TI0 ==0)

			     {
					  SBUF0 = outBuffer[count]; //-- send the sent_byte to output
					  small_delay(100);
				  
				  }  
				 
	   
		    	TI0 = 0;
		   
	         }//for 
 

}//UART0_ISR

/////////////////////////////////////////////////////////////////////////

void INT1_ISR(void) interrupt 2 
{
	pulses++;
	actual_speed= pulses/312;

}



//--------------------------------------------------------------
void main(void)
{
		blink_speed = 0;
		 
		new_cmd_received = 0; 
		port5=0;
		command = 0;
		message = 0;
		i = 0;
	    count = 0;
		random =0; 

        P5 = 0x0F;			//-- Turn the 4 green LEDs off
		P1 = 0x00;

		LED_count = 0;
		LED = 0;
		DIR = 0;
		EA = 0; //-- disable global interrupts
		WDTCN = 0xDE; //-- disable watchdog timer
		WDTCN = 0xAD;
		Init_Clock();
		lcd_init();
	    lcd_curser(0); 
		Init_Port();
		Init_ADC0();

		Init_Timer3(BLINKCLK/12/blink_speed); 
		Init_UART0();
		AD0BUSY = 1;	// write 1 to ADC0BUSY and start ADC0 conversion 
		EA = 1; //-- enable global interrupts
			
		

		while(1) //-- go on forever
		{
            lcd_goto(0x80);   //-- go to Second Row
			
			//RPM = 115000/321/pulses;
			time_in_sec=((time_in_sec*10^6)/728286)+1;
			pulses=642;
			RPM=pulses/(time_in_sec*60);
			printf("T:%3d", time_in_sec);
			//printf("P:%9d", pulses);
			printf("R:%6d", RPM);
			command=1; // send code 1 to pc
			message = RPM; // send message to pc that the RPM is...

			if( i == 3000)
			{
			   	i = -1;
			   	RI0 = 1;
			
			}
			//else
		     //  RI0 == 0;

		
       		if ( blink_speed==0)
			{
				LED=0;
			}

           if (new_cmd_received == 1)
	       {
		   

 	
		    switch (received_byte)
				{
				case 0:

					lcd_clear();
				//-- Display
					lcd_goto(0x00) ;   //-- go to first Row
				    printf("  ");
					huge_delay(20);
					blink_speed = 0;
					DIR=0;
					break; 

				case 1: 

				    lcd_clear();
					//-- Display
					lcd_goto(0x00) ;   //-- go to first Row
				    printf("  Left Slow"  );
					huge_delay(20);
					blink_speed = 1; 
					break; // slow

				case 2: 

					 lcd_clear();
					//-- Display
					lcd_goto(0x00) ;   //-- go to first Row
				    printf("  Left Medium " );
					huge_delay(20);
					blink_speed = 10; 
					break; // medium

				case 3:

					lcd_clear();
				//-- Display
					lcd_goto(0x00) ;   //-- go to first Row
				    printf("  Left Fast");
					huge_delay(20);
					blink_speed = 50;
					break; // fast

				case 4: 

				    lcd_clear();
					//-- Display
					lcd_goto(0x00) ;   //-- go to first Row
				    printf("  Right Slow"  );
					huge_delay(20);
					blink_speed = 1; 
					break; // slow

				case 5: 

					 lcd_clear();
					//-- Display
					lcd_goto(0x00) ;   //-- go to first Row
				    printf("  Right Medium " );
					huge_delay(20);
					blink_speed = 10; 
					break; // medium

				case 6:

					lcd_clear();
				//-- Display
					lcd_goto(0x00) ;   //-- go to first Row
				    printf("  Right Fast");
					huge_delay(20);
					blink_speed = 50;
					break; // fast

				case 7:

					lcd_clear();
				//-- Display
					lcd_goto(0x00) ;   //-- go to first Row
				    printf("  Stop");
					huge_delay(20);
					blink_speed = 0;
					break; // 

				case 8:

					DIR=1;
					break; // 

				case 9:

					DIR=0;
					break; // fast
				
				default : blink_speed = 0; break;
     			}

			EA = 0; 
			Init_Timer3(BLINKCLK/12/blink_speed);
			EA = 1; //-- enable interrupts
			new_cmd_received = 0;

		}//if

             i++;
	}//while

}//main



//------------------- LCD functions -----------------------------------------------
#pragma OPTIMIZE (7)
void lcd_init(void)
{
	LCD_CTRL_PORT = LCD_CTRL_PORT & ~RS_MASK;	// RS = 0
	LCD_CTRL_PORT = LCD_CTRL_PORT & ~RW_MASK;	// RW = 0
	LCD_CTRL_PORT = LCD_CTRL_PORT & ~E_MASK;	//  E = 0
	large_delay(200);				  // 16ms delay

	LCD_DAT_PORT = 0x38;			  // set 8-bit mode
	pulse_E();
	large_delay(50);				  // 4.1ms delay

	LCD_DAT_PORT = 0x38;			  // set 8-bit mode
	pulse_E();
	large_delay(2);				  // 1.5ms delay

	LCD_DAT_PORT = 0x38;			  // set 8-bit mode
	pulse_E();
	large_delay(2);				  // 1.5ms delay

	lcd_cmd(0x06);					  // curser moves right
	lcd_cmd(0x01);					  // clear display
	lcd_cmd(0x0E);					  // display and curser on
}

#pragma OPTIMIZE (9)



//---------------------------------------------------------------------------------
// lcd_busy_wait
//---------------------------------------------------------------------------------
//
// wait for the busy bit to drop
//
void lcd_busy_wait(void)
{
	LCD_DAT_PORT = 0xFF;
	LCD_CTRL_PORT = LCD_CTRL_PORT & ~RS_MASK;	// RS = 0
	LCD_CTRL_PORT = LCD_CTRL_PORT | RW_MASK;	// RW = 1
	small_delay(1);
	LCD_CTRL_PORT = LCD_CTRL_PORT | E_MASK;	//  E = 1
//	TB_GREEN_LED = 1;
	do
	{								  // wait for busy flag to drop
		small_delay(1);
	} while ((LCD_DAT_PORT & 0x80) != 0);
//	TB_GREEN_LED = 0;
}


//---------------------------------------------------------------------------------
// lcd_dat (putchar)
//---------------------------------------------------------------------------------
//
// write a character to the lcd screen
//
char putchar(char dat)
{
	lcd_busy_wait();
	LCD_CTRL_PORT = LCD_CTRL_PORT | RS_MASK;	// RS = 1
	LCD_CTRL_PORT = LCD_CTRL_PORT & ~RW_MASK;	// RW = 0
	LCD_DAT_PORT = dat;
	pulse_E();
	return 1;
}


//---------------------------------------------------------------------------------
// lcd_cmd
//---------------------------------------------------------------------------------
//
// write a command to the lcd controller
//
void lcd_cmd(char cmd)
{
	lcd_busy_wait();
	LCD_CTRL_PORT = LCD_CTRL_PORT & ~RS_MASK;	// RS = 0
	LCD_CTRL_PORT = LCD_CTRL_PORT & ~RW_MASK;	// RW = 0
	LCD_DAT_PORT = cmd;
	pulse_E();

}


//---------------------------------------------------------------------------------
// lcd_goto
//---------------------------------------------------------------------------------
//
// change the text entry point
//
void lcd_goto(char addr)
{
	lcd_cmd(addr | 0x80);
}

//---------------------------------------------------------------------------------
// lcd_clear
//---------------------------------------------------------------------------------
void lcd_clear(void)
{
	lcd_cmd(0x01);	//-- clear LCD display
	lcd_cmd(0x80);	//-- curser go to 0x00
}

//---------------------------------------------------------------------------------
// lcd_curser
//---------------------------------------------------------------------------------
void lcd_curser(bit on)        // 1 displays curser, 0 hides it
{
	if (on)
		lcd_cmd(0x0E);	
	else
		lcd_cmd(0x0C);
}



//---------------------------------------------------------------------------------
// delay routines
//---------------------------------------------------------------------------------

void small_delay(char d)
{
	while (d--);
}


void large_delay(char d)
{
	while (d--)
		small_delay(255);
}


void huge_delay(char d)
{
	while (d--)
		large_delay(255);
}

//------------------- End Of File ---------------------------------------------------