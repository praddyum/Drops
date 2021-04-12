## Let's setup Firebase Realtime database with Unity 2019 & 2020

These steps worked fine w.r.t firebase `sdk 7.1.0`.

I have declared a global variable Database .

1. Create a new project in Unity and switch it to `Android`.
2. In `player settings` give `Company Name` and `Product Name`.
3. In `Player Setting` -> `Publishing Setting` create a Keystore.
    - Click in `Keystore Manager` 
     
      ![image](https://user-images.githubusercontent.com/43271546/111471138-9449de80-874e-11eb-8ac3-fe8d7c4f4197.png)
    
    - `Keystore` -> `CreateNew` -> `InDedicatedLocation` and fill the details.
      
      ![image](https://user-images.githubusercontent.com/43271546/111471633-1c2fe880-874f-11eb-9784-6bef164f90d6.png)

    - Add Key
    
    Note: Multiple gams/apps under same Keystore the differentiated by Alias so use that field to give it a unique name with a different password.
    
4. Now head over to [Firebase Console](https://console.firebase.google.com/) and create a new project.
    
    ![image](https://user-images.githubusercontent.com/43271546/111472412-edfed880-874f-11eb-88c2-d1008e5daa1e.png)

5. Give it a name and turn off analytics for now.

6. Click on the Unity Icon to add the application
    
    ![image](https://user-images.githubusercontent.com/43271546/111473895-80ec4280-8751-11eb-9ea9-74a91f0d7261.png)

7. Register as Android app and in Unity player Setting get the package name and paste it here.For App nick name give it any. And click on Register.
    
    ![image](https://user-images.githubusercontent.com/43271546/111474470-1ee00d00-8752-11eb-8d9a-274d0ec310ad.png)

8. `Next` 

9. Download the SDK and press `Next` -> `Continue to Console`

10. Now open the terminal and type `keytool -list -keystore </PATH to your generated keystore>`
    ![image](https://user-images.githubusercontent.com/43271546/111482342-d298cb00-8759-11eb-8c2b-09e1a5fcde18.png)

11. On firebase console open `⚙️`-> `Project Settings`-> `Your Apps` and `Add fingerprint`
    ![image](https://user-images.githubusercontent.com/43271546/111483074-797d6700-875a-11eb-9d51-ef56fe927047.png)

12. Now under Build panel click on `Realtime Database`-> `Create Database`
    ![image](https://user-images.githubusercontent.com/43271546/111483479-d1b46900-875a-11eb-9bf8-916d9179dbad.png)

13. Choose (us-central1) for `Database Location` and `Start in test mode` and `Enable`.
14. Move to `⚙️`-> `Project Settings`-> `Your Apps` and download the `google-services.json` and `SDK`
    
    ![image](https://user-images.githubusercontent.com/43271546/111484461-ca418f80-875b-11eb-931a-decb2a04b9a7.png)

15. Open the Unity project and import packages
    - Import google-services.json file under Assets folder
    - Import Firebase.Database package from SDK. `Import Package`-> `Custom Package`-> and locate the file under downloaded SDK zip(Obvio you need to unzip it beforehand)
        ![image](https://user-images.githubusercontent.com/43271546/111485414-9b77e900-875c-11eb-8f88-22daf782b4e9.png)
    
    - Import it and if it asks to download some dependency enable it and let it setup the stage for you.
        ![image](https://user-images.githubusercontent.com/43271546/111485820-f7db0880-875c-11eb-8d03-1096509b5ba3.png)

16. Let's test it:
    - Make an empty game object and assign it a script(Say: realtime) with code
        ```
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using Firebase.Database;

        public class realtime : MonoBehaviour
        {

            DatabaseReference reference;
            int a=0;
            void Start()
            {
                reference= FirebaseDatabase.DefaultInstance.RootReference;   
            }

            public void update_value(){

                reference.Child("test").SetValueAsync(a);
                a=a+1;
            }
        }

        ```
    -  Open `UI`-> `Button` and under Inspector Panel of Button `On Click` press on `+` drag and drop the created empty game object above and under function select `realtime`-> `update_value`.
    -  Play the game and click on button you'll see the values changing on `Realtime Database` console over Firebase.
    -  Visit [Docs](https://firebase.google.com/docs/database/unity/save-data) to learn other ways to send and receive data over firebase.
    -  If any error occurs(Can't make Firebase App etc) try downloading the google-services.json again(Step 14) and replacing it with old file under `Asset folder`. 

<hr />

## For Unity 2020

The process is same as above but if it gives some error you can try this also:
    
   Create a folder `StreamingAssets` under `ssets` and place your google-services JSON file inside that or you'll face the error. So your final path will be `Assets/StreamingAssets/google-services.json`
   
