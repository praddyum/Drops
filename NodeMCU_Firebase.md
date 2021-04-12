
## Let's first create a realtime database

1. Visit : [Firebase Console](https://console.firebase.google.com)
2. Create a `new project`. Give it a unique name and disable analytics option(as we don't need them in this project).

   ![image](https://user-images.githubusercontent.com/43271546/110456974-2cf9b200-80f0-11eb-883f-4be2bbb9639c.png)

3. Select `Realtime Database` option and `Create Database`

   ![image](https://user-images.githubusercontent.com/43271546/110457767-fd977500-80f0-11eb-868a-554fac3c8dcb.png)

4. Set the Realtime Database Location to `United States(us-central-1)` and choose `Start in Test Mode`

5. Note down the URL to do API call. In Test Mode anyone can query at this API to fetch JSON data so be sure not to do the same at production level.

   ![image](https://user-images.githubusercontent.com/43271546/110458731-1ce2d200-80f2-11eb-9c3d-ce771505290c.png)

And we are done for now with Firebase.

<hr />

## Setting Up Arduino IDE for NodeMCU ESP8266

1. Visit `Sketch` -> `Include Libraries` -> `Manage Libraries`.
2. Download `Firebase ESP8266 Client` by `Mobizt`.

<hr />

## Basic Run

1. Open `File` -> `Examples` -> `Firebase esp8266 Client` -> `Begineers Start here`
2. Now fill `WIFI_SSID` and `WIFI_PASSWORD` with your wifi name and password.
3. For `FIREBASE_HOST` get the value from firebase console. remove the starting `https://` and ending `/`
   
   ![image](https://user-images.githubusercontent.com/43271546/110756212-e8952000-826f-11eb-8c3b-1b691b61068d.png)
   
4. For `FIREBASE_AUTH` get the value from firebase console. `⚙️` -> `Users and Permissions` -> `Service Accounts` -> `Database Secrets`
   
   ![image](https://user-images.githubusercontent.com/43271546/110755858-70c6f580-826f-11eb-88ab-35b63520c48c.png)

