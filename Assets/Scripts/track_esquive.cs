using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class track_esquive : MonoBehaviour
{
    public SteamVR_Action_Boolean Track;
    public SteamVR_Input_Sources hand;
    public UnityEvent activate_toe;
    public UnityEvent activate_esquive;
    public UnityEvent compute_score_function;
    public UnityEvent esquive;
    public UnityEvent TP_Avatar;
    public UnityEvent punch;

    /*
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is down");
        activate_toe?.Invoke();
        activate_esquive?.Invoke();
        TP_Avatar?.Invoke();
    }
    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is Up");
        compute_score_function?.Invoke();

    }   
    */

    public void ButtonDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is down");
        activate_esquive?.Invoke();
        activate_toe?.Invoke();
        TP_Avatar?.Invoke();
        punch?.Invoke();
    }
 
        void Start()
        {
            Track.AddOnStateDownListener(ButtonDown, hand);            
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown("space"))
            {
            Debug.Log("Trigger is down");
            activate_esquive?.Invoke();
            activate_toe?.Invoke();
            TP_Avatar?.Invoke();
            punch?.Invoke();

        }
               
            
        }
    }
