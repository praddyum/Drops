using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_S : MonoBehaviour
{   
    public void destroy(){
        if(transform.childCount>3){
            Destroy (GetComponent<Transform> ().GetChild (1).gameObject);
            Destroy (GetComponent<Transform> ().GetChild (2).gameObject);
            Destroy (GetComponent<Transform> ().GetChild (3).gameObject);
            Destroy (GetComponent<Transform> ().GetChild (4).gameObject);
        }
        
    }
     
}
