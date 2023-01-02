using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class MenuPunch : MonoBehaviour 
{   
    public Animator anim;
    public float timeToChangePunch;
    private float currentTime;
    // public ScoreSO MyScoreScript; // dans ce script, on doit avoir le booléeen ScoreHasUpdated qui vaut true dès que le score change dans update
    public GameObject whatToCall;
    public RuntimeAnimatorController newController;
    GameObject[] allPunch = new GameObject[6];
    private GameObject UppercutArrièreLent;
    private GameObject UppercutAvantLent; 
    private GameObject CrochetArrièreLent;
    private GameObject CrochetAvantLent; 
    private GameObject DirectArrièreLent; 
    private GameObject DirectAvantLent; 
    void Awake () {
        currentTime = timeToChangePunch;
        anim.runtimeAnimatorController = newController;
        UppercutArrièreLent = Resources.Load<GameObject>( "Sofia Animations/UppercutArrièreLent");
        UppercutAvantLent = Resources.Load<GameObject>( "Sofia Animations/UppercutAvantLent");
        DirectAvantLent = Resources.Load<GameObject>( "Sofia Animations/DirectAvantLent");
        DirectArrièreLent = Resources.Load<GameObject>( "Sofia Animations/DirectArrièreLent");
        CrochetAvantLent = Resources.Load<GameObject>( "Sofia Animations/CrochetAvantLent");
        CrochetArrièreLent = Resources.Load<GameObject>( "Sofia Animations/CrochetArrièreLent");
    }
    
     // Use this for initialization
    void Start () {
        allPunch[0]=CrochetArrièreLent ;
        allPunch[1]=CrochetAvantLent;
        allPunch[2]=DirectArrièreLent;
        allPunch[3]=DirectAvantLent;
        allPunch[4]=UppercutAvantLent;
        allPunch[5]=UppercutArrièreLent;
        ChangePunch();
    }
     
     // Update is called once per frame
    void Update () {
        currentTime -= Time.deltaTime;
        if (currentTime<=0)
        {
            ChangePunch();
        }
        else
        {
            anim.SetBool("DoUppercutArrièreLent", false);
            anim.SetBool("DoUppercutAvantLent", false);
            anim.SetBool("DoCrochetArrièreLent", false);
            anim.SetBool("DoCrochetAvantLent", false);
            anim.SetBool("DoDirectArrièreLent", false);
            anim.SetBool("DoDirectAvantLent", false);
        }
 
    }
 
        public void ChangePunch() {
        int whichPunch = Random.Range(0, allPunch.Length);
     
        whatToCall = allPunch[whichPunch];
 
        anim.SetBool("DoUppercutArrièreLent",false);
        anim.SetBool("DoUppercutAvantLent",false);
        anim.SetBool("DoCrochetArrièreLent",false);
        anim.SetBool("DoCrochetAvantLent",false);
        anim.SetBool("DoDirectArrièreLent",false);
        anim.SetBool("DoDirectAvantLent",false);
        if (whatToCall==UppercutArrièreLent) {
            anim.SetBool("DoUppercutArrièreLent",true);
        }
        if (whatToCall==UppercutAvantLent) {
            anim.SetBool("DoUppercutAvantLent",true);
        }
        if (whatToCall==CrochetArrièreLent) {
            anim.SetBool("DoCrochetArrièreLent",true);
        }
        if (whatToCall==CrochetAvantLent) {
       
            anim.SetBool("DoCrochetAvantLent",true);
        }
        if (whatToCall==DirectAvantLent) {
          
            anim.SetBool("DoDirectAvantLent",true);
        }
        if (whatToCall==DirectArrièreLent) {
            
            anim.SetBool("DoDirectArrièreLent",true);
        }
        currentTime = timeToChangePunch;
    }
        public GameObject return_whatToCall()
    {
        return (whatToCall);
    }
}
    

