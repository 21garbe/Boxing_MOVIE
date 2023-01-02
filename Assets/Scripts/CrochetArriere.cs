using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class CrochetArriere : MonoBehaviour 
{
    public Animator anim;
    // public ScoreSO MyScoreScript; // dans ce script, on doit avoir le booléeen ScoreHasUpdated qui vaut true dès que le score change dans update
    public GameObject whatToCall;
    public RuntimeAnimatorController newController;
    GameObject[] allPunch = new GameObject[1];
    private GameObject CrochetArrièreLent;

    public void set_active()
    {
        anim.SetBool("active", true);
    }
    void Awake()
    {
        anim.runtimeAnimatorController = newController;
        CrochetArrièreLent = Resources.Load<GameObject>("Sofia Animations/CrochetArrièreLent");
    }

    // Use this for initialization
    void Start()
    {
        allPunch[0] = CrochetArrièreLent;
        ChangePunch();
    }

    // Update is called once per frame
    void Update()
    {
        //ScoreUpdates = MyScoreScript.ScoreHasUpdated;
        // if (ScoreUpdates) {
        //     ChangePunch();
        //}
        //else {


        //}

    }

    public void ChangePunch()
    {
        int whichPunch = Random.Range(0, allPunch.Length);
        whatToCall = allPunch[whichPunch];
        anim.SetBool("DoUppercutArrièreLent", false);
        anim.SetBool("DoUppercutAvantLent", false);
        anim.SetBool("DoCrochetArrièreLent", false);
        anim.SetBool("DoCrochetAvantLent", false);
        anim.SetBool("DoDirectArrièreLent", false);
        anim.SetBool("DoDirectAvantLent", false);
        if (whatToCall == CrochetArrièreLent)
        {
            anim.SetBool("DoCrochetArrièreLent", true);
        }
        anim.SetBool("active", false);
    }
    public GameObject return_whatToCall()
    {
        return (whatToCall);
    }
}






