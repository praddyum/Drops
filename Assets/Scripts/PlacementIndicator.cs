using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{

    private ARRaycastManager rayManager;
    private GameObject visual;
    public onoffbutton button_status;
    public TextMeshProUGUI text;
    public GameObject toggbutton;
    public GameObject moisture;
    public GameObject instruction;

    //object spawner - Script2
    public GameObject objectToSpawn;
    private PlacementIndicator positionIndicator;
    public GameObject watercan;

    private int a=0;

    // Start is called before the first frame update
    void Start()
    {
        //src: https://www.youtube.com/watch?v=FGh7f-PaGQc
        // get the components
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        // hide the placement visual
        visual.SetActive(false);

        //hide motor button
        toggbutton.SetActive(false);

        //hide moisture
        moisture.SetActive(false);

        //scrip 2
        positionIndicator = FindObjectOfType<PlacementIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        // shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        //if we hit an AR plane then update the position and rotation
        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
            text.text = "Tap to place the plant";

            if (!visual.activeInHierarchy && a==0)
                visual.SetActive(true);

        }

        //script2
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && a==0)
        {
            instruction.SetActive(false);
            toggbutton.SetActive(true);
            moisture.SetActive(true);

            GameObject obj = Instantiate(objectToSpawn, positionIndicator.transform.position, positionIndicator.transform.rotation);

            GameObject obj2 = Instantiate(watercan, positionIndicator.transform.position, positionIndicator.transform.rotation);

            button_status.watercan = obj2;

            obj2.transform.position += new Vector3(0.615f, 0.6111506f, 0.017f);
            
            Vector3 temp = transform.rotation.eulerAngles;
            temp.x = -38.721f;
            temp.y = 83.415f;
            temp.z = 0.017f;

            obj2.transform.rotation = Quaternion.Euler(temp);

            obj2.SetActive(false);

            a = 1;
            visual.SetActive(false);
        }
    }
}
