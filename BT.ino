#include <SoftwareSerial.h>


/*
  Blink
 Turns on an LED on for one second, then off for one second, repeatedly.
 
 This example code is in the public domain.
 */


int rx_pin = 0;     // setting digital pin 0 to be the receiving pin
int tx_pin = 1;     // setting the digital pin 1 to be the transmitting pin


// the setup routine runs once when you press reset:
void setup() {                
  // initialize the digital pin as an output.

  // Serial.begin(115200);  
  pinMode(rx_pin, INPUT);  // receiving pin as INPUT
  pinMode(tx_pin, OUTPUT);
  bluetoothInitiate(); // this function will initiate our bluetooth (next section)
}  


void bluetoothInitiate(){
  // this part is copied from the Seeeduino example*
  Serial.begin(115200); // this sets the the module to run at the default bound rate
  Serial.print("\r\n+STWMOD = 0\r\n");        //set the bluetooth work in slave mode
  Serial.print("\r\n+STNA=SeeedBTSlave\r\n"); //set the bluetooth name as "SeeedBTSlave"
  Serial.print("\r\n+STOAUT=1\r\n");          // Permit Paired device to connect me
  Serial.print("\r\n+STAUTO=0\r\n");          // Auto-connection should be forbidden here
  delay(2000);                            // This delay is required.
  Serial.print("\r\n+INQ=1\r\n");             //make the slave bluetooth inquirable
  delay(15000);                            // This delay is required.
  Serial.flush(); 
  Serial.print("Bluetooth connection established correctly!"); // if connection is successful then print to the master device
  Serial.print("Hello");
}
// the loop routine runs over and over again forever:

void loop() {

  
  delay(1000);               // wait for a second
  char buffer;               // this is where we are going to store the received character

    while(Serial.available()){     // this will check if there is anything being
    // sent to the Bluetooth from another device
    buffer = Serial.read(); // this will save anything that is being sent to the Bluetooth
    Serial.print(buffer);   // this will print to the local serial (tools->serial monitor)
    
  }
  // this is for recieving on the device with bluetooth, now we can make it send stuff too!
//  while(Serial.available()){   // this will check if any data is sent
//    // from the local terminal
//    buffer = Serial.read(); // get what the terminal sent
//    Serial.print(buffer);       // and now send it to the master device
//
//  }
  //delay(1000);               // wait for a second
}



