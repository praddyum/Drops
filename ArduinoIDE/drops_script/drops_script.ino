
/**
 * Modified by Praddyum Verma
 * Github:https://github.com/Praddy2009

   Kindly update the firbase_host adn Firebase_Auth
*/



#include "FirebaseESP8266.h"
#include <ESP8266WiFi.h>
#include <WiFiManager.h>
#include <ESP8266WiFi.h>
#include <FirebaseESP8266.h>

#define FIREBASE_HOST "project.firebaseio.com"
#define FIREBASE_AUTH "DatabaseSecretKey"

//2. Define FirebaseESP8266 data object for data sending and receiving
FirebaseData fbdo;

int sensor=0; //Sensor input ar Analog pin A0
int Out=16;  //D0 pin for motor Signal
int value=0;
int a=130;
int result;
int mutex=0;  //To remove race condition
void setup()
{
  WiFi.mode(WIFI_STA);
  Serial.begin(115200);
  Serial.println();

  pinMode(Out, OUTPUT); // initialize digital(D0) motor as an output.
  delay(10);
  digitalWrite(Out, LOW); // initialize pin as off (active LOW)

  WiFiManager wm;
  //wm.resetSettings();
  bool res;
  res = wm.autoConnect("Drops","t00r1947");

  if(!res) {
        Serial.println("Failed to connect");
        // ESP.restart();
    }
  else {
        //if you get here you have connected to the WiFi    
        Serial.println("connected...yeey :)");
    }
  

  //3. Set your Firebase info

  Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);

  //4. Enable auto reconnect the WiFi when connection lost
  Firebase.reconnectWiFi(true);
  

}

void updates(){
  int temp;
  //read data of 3rd
  if(Firebase.getInt(fbdo, "/plant/moisture3"))
      {
        //Success
        //Serial.print("Get int data success for moisture 3, int = ");
        //Serial.println(fbdo.intData());
        temp=fbdo.intData();
      }else{
        //Failed?, get the error reason from fbdo
    
        //Serial.print("Error in getting 3rd, ");
        //Serial.println(fbdo.errorReason());
      }
      
    //Assign value to 4th
    if(Firebase.setInt(fbdo, "/plant/moisture4", temp))
      {
        //Success
         //Serial.println("Set int data success for 4th");
    
      }else{
        //Failed?, get the error reason from fbdo
    
        //Serial.print("Error in setInt, ");
        //Serial.println(fbdo.errorReason());
      }
      
    //read data of 2rd
    if(Firebase.getInt(fbdo, "/plant/moisture2"))
      {
        //Success
        //Serial.print("Get int data success for moisture 2, int = ");
        //Serial.println(fbdo.intData());
        temp=fbdo.intData();
      }else{
        //Failed?, get the error reason from fbdo
    
        //Serial.print("Error in getting 2nd, ");
        //Serial.println(fbdo.errorReason());
      }
      
    //Assign value to 3rd
    if(Firebase.setInt(fbdo, "/plant/moisture3", temp))
      {
        //Success
         //Serial.println("Set int data success for 3rd");
    
      }else{
        //Failed?, get the error reason from fbdo
    
        //Serial.print("Error in setInt, ");
        //Serial.println(fbdo.errorReason());
      }
      

    //read data of 1st
    if(Firebase.getInt(fbdo, "/plant/moisture1"))
      {
        //Success
        //Serial.print("Get int data success for moisture 1, int = ");
        //Serial.println(fbdo.intData());
        temp=fbdo.intData();
      }else{
        //Failed?, get the error reason from fbdo
    
        //Serial.print("Error in getting 1st, ");
        //Serial.println(fbdo.errorReason());
      }
          

    //Assign value to 2nd
    if(Firebase.setInt(fbdo, "/plant/moisture2", temp))
      {
        //Success
         //Serial.println("Set int data success for 3rd");
    
      }else{
        //Failed?, get the error reason from fbdo
    
        //Serial.print("Error in setInt, ");
        //Serial.println(fbdo.errorReason());
      }

    //Assign to 1st      
    
    if(Firebase.setInt(fbdo, "/plant/moisture1", value))
      {
        //Success
         //Serial.println("Set int data success");
    
      }else{
        //Failed?, get the error reason from fbdo
    
        //Serial.print("Error in setInt, ");
        //Serial.println(fbdo.errorReason());
      }
      mutex=1;
}

void loop()
{
  int timer=millis();
  timer=timer/1000;
  //1hr confirmed schedule
  if(timer==a){
    value=analogRead(sensor);
    value=value/10;
    //Serial.println(a);

    //Call for update
    updates();  
      //Check for reset
    if(a>86200){
        ESP.reset();
      }
      //Update value of a
     a=a+3600;                //1hr interval
     int timeend=millis();
     timeend/1000;
     //Serial.println(timeend); 
    }

    //read the latest data for any edge case changes
    int old_val;
    value=analogRead(sensor);
    value=value/10;
    if(Firebase.getInt(fbdo, "/plant/moisture1"))
      {
        //Success
        //Serial.print("Get int data success for moisture 1, int = ");
        //Serial.println(fbdo.intData());
        old_val=fbdo.intData();
      }else{
        //Failed?, get the error reason from fbdo
    
        //Serial.print("Error in getting 3rd, ");
        //Serial.println(fbdo.errorReason());
      }
      result=abs(value-old_val);
    if(result>20 && mutex){
      //Serial.print("Call to update on abs");
      //Serial.println(value);
      //Serial.println(old_val);
      //Serial.print(result);
        updates();
    }
    
  if(Firebase.getInt(fbdo, "/plant/mstatus"))
  {
    //Success
    //Serial.print("Get int data success, int = ");
    //Serial.println(fbdo.intData());

    if(fbdo.intData()==1){
      digitalWrite(Out,HIGH); // turn the LED on (HIGH is the voltage level)
      
      //Automatic Switch off the motor on 100% moisture
      value=analogRead(sensor);
      value=value/10;
      if(value==32){
        digitalWrite(Out,LOW);   //Switch off the motor
        Serial.print("Call to update on mstatus 1");
        updates();               //Update values
        }
      
    }
    else if(fbdo.intData()==0){
      digitalWrite(Out, LOW); // turn the Motor off (LOW is the voltage level)
    }
    else{
      //Serial.print("Error data fetch");
    }
  }else{
    //Failed?, get the error reason from fbdo

    //Serial.print("Error in getInt, ");
    //Serial.println(fbdo.errorReason());
  }
  
}
