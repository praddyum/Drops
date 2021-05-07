using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using TMPro;
using System;
using DG.Tweening;

public class Firebase_Script : MonoBehaviour
{
   
    DatabaseReference reference;
    string text_place;
    public TextMeshProUGUI text;
    private int val;
    private Decimal val2;
    public Windowgraph graph;
    public destroy_S destroy; 
  

    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        //takes a snapshot whenever it changes
        reference.Child("plant").ValueChanged += HandleValueChanged;
        
        
    }


    //Function which updates the text in case of value updated
    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        /*
        val = Convert.ToInt32(args.Snapshot.Child("moisture1").Value);
        Debug.Log(val);
        val2=Decimal.Divide((102 - val) , 70);
        Debug.Log(val2);
        val2 = val2*100;
        Debug.Log(val2);
        val2 = Math.Round(val2, 0);
        text_place = val2.ToString();
        text.text = text_place + "%";
        */

        /*CodemonkeyImplementation*/
        //moisture 4
        destroy.destroy();
        val = Convert.ToInt32(args.Snapshot.Child("moisture4").Value);
        val2=Decimal.Divide((102 - val) , 70);
        val2 = val2*100;
        val2 = Math.Round(val2, 0);
        val2=val2*3;
        Debug.Log(val2);
        graph.CreateCircle(new Vector2(116,(float)val2));

        //moisture 3
        val = Convert.ToInt32(args.Snapshot.Child("moisture3").Value);
        val2=Decimal.Divide((102 - val) , 70);
        val2 = val2*100;
        val2 = Math.Round(val2, 0);
        val2=val2*3;
        Debug.Log(val2);
        graph.CreateCircle(new Vector2(232,(float)val2));

        //moisture 2
        val = Convert.ToInt32(args.Snapshot.Child("moisture2").Value);
        val2=Decimal.Divide((102 - val) , 70);
        val2 = val2*100;
        val2 = Math.Round(val2, 0);
        val2=val2*3;
        Debug.Log(val2);
        graph.CreateCircle(new Vector2(348,(float)val2));

        //moisture 1
        val = Convert.ToInt32(args.Snapshot.Child("moisture1").Value);
        val2=Decimal.Divide((102 - val) , 70);
        val2 = val2*100;
        val2 = Math.Round(val2, 0);
        val2=val2*3;
        Debug.Log(val2);
        graph.CreateCircle(new Vector2(446,(float)val2));

        /*Codemonkey Implementation ends*/

    }

    

}
