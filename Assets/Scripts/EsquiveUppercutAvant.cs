
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using Valve.VR;
using UnityEngine.Events;

public class EsquiveUppercutAvant : MonoBehaviour
{
    public Animator anim;
    public GameObject player;

    public RuntimeAnimatorController newController;
    public ScoreSO MyScoreScript;
    public UppercutAvant UppercutAvant;
    public bool active ;    
    private GameObject UppercutArrièreLent_esquive;
    private GameObject UppercutAvantLent_esquive;
    private GameObject CrochetArrièreLent_esquive;
    private GameObject CrochetAvantLent_esquive;
    private GameObject DirectArrièreLent_esquive;
    private GameObject DirectAvantLent_esquive;
    private GameObject UppercutArrièreLent;
    private GameObject UppercutAvantLent;
    private GameObject CrochetArrièreLent;
    private GameObject CrochetAvantLent;
    private GameObject DirectArrièreLent;
    private GameObject DirectAvantLent;

    

    void Awake()
    { 
        anim.runtimeAnimatorController = newController;
       
        UppercutArrièreLent_esquive = Resources.Load<GameObject>("Sofia Animations/Esquive/retrait");

        UppercutAvantLent_esquive = Resources.Load<GameObject>("Sofia Animations/Esquive/retrait");
    
        DirectAvantLent_esquive = Resources.Load<GameObject>("Sofia Animations/Esquive/esquive_droite");
       
        DirectArrièreLent_esquive = Resources.Load<GameObject>("Sofia Animations/Esquive/esquive_gauche");
        
        CrochetAvantLent_esquive = Resources.Load<GameObject>("Sofia Animations/Esquive/esquive_dessous_droite");
        
        CrochetArrièreLent_esquive = Resources.Load<GameObject>("Sofia Animations/Esquive/esquive_dessous_gauche");

        UppercutArrièreLent = Resources.Load<GameObject>("Sofia Animations/UppercutArrièreLent");
        UppercutAvantLent = Resources.Load<GameObject>("Sofia Animations/UppercutAvantLent");
        DirectAvantLent = Resources.Load<GameObject>("Sofia Animations/DirectAvantLent");
        DirectArrièreLent = Resources.Load<GameObject>("Sofia Animations/DirectArrièreLent");
        CrochetAvantLent = Resources.Load<GameObject>("Sofia Animations/CrochetAvantLent");
        CrochetArrièreLent = Resources.Load<GameObject>("Sofia Animations/CrochetArrièreLent");
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is down");
        ChangeEsquive();
    }

    // Use this for initialization
    public void activate_esquive()
    {
        anim.SetBool("active", true);
        Debug.Log("esquive active");
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void ChangeEsquive()
    {
            GameObject whatToCall = UppercutAvant.whatToCall;
            Debug.Log(whatToCall);
            anim.SetBool("DoUppercutArrièreLent", false);
            anim.SetBool("DoUppercutAvantLent", false);
            anim.SetBool("DoCrochetArrièreLent", false);
            anim.SetBool("DoCrochetAvantLent", false);
            anim.SetBool("DoDirectArrièreLent", false);
            anim.SetBool("DoDirectAvantLent", false);
            anim.SetBool("DoTroisDirectsLents", false);
           
            if (whatToCall == UppercutAvantLent)
            {
                anim.SetBool("DoUppercutAvantLent", true);
            }
        anim.SetBool("active", false);
        
        

        
       
    }
}
