using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class s_LineRenderer : MonoBehaviour
{

    //Declare a LineRenderer to store the component attached to the GameObject. 
    [SerializeField] LineRenderer rend;
    public GameObject panel;
    public Image img;
    public Button btn;
    public SteamVR_Action_Boolean Track;
    public SteamVR_Input_Sources hand;

    //Settings for the LineRenderer are stored as a Vector3 array of points. Set up a V3 array to //initialize in Start. 
    Vector3[] points;
    //Start is called before the first frame update
    void Start()
    {
        //get the LineRenderer attached to the gameobject. 
        rend = gameObject.GetComponent<LineRenderer>();
        img = panel.GetComponent<Image>();
        //initialize the LineRenderer
        points = new Vector3[2];
        //set the start point of the linerenderer to the position of the gameObject. 
        points[0] = Vector3.zero;
        //set the end point 20 units away from the GO on the Z axis (pointing forward)
        points[1] = transform.position + new Vector3(0, 0, 20);
        //finally set the positions array on the LineRenderer to our new values
        rend.SetPositions(points);
        rend.enabled = true;

        Track.AddOnStateDownListener(TriggerDown, hand);
        Track.AddOnStateUpListener(TriggerUp, hand);
    }

    public LayerMask layerMask;
    public bool AlignLineRenderer(LineRenderer rend)
    {
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        bool hitBtn = false;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            points[1] = transform.forward + new Vector3(0, 0, hit.distance);
            rend.startColor = Color.red;
            rend.endColor = Color.red;
            btn = hit.collider.gameObject.GetComponent<Button>();
            hitBtn = true;
            Debug.Log(hit.collider);
        }
        else
        {
            points[1] = transform.forward + new Vector3(0, 0, 30);
            rend.startColor = Color.green;
            rend.endColor = Color.green;
            hitBtn = false;
        }
        rend.material.color = rend.startColor;
        rend.SetPositions(points);
        return hitBtn;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is down");
        if (AlignLineRenderer(rend))
        {
            btn.onClick.Invoke();
        }

    }
    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is Up");

    }

    // Update is called once per frame
    void Update()
    {
        AlignLineRenderer(rend);
    }

}
