using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class UppercutArriere : MonoBehaviour
{
    public Animator anim;
    // public ScoreSO MyScoreScript; // dans ce script, on doit avoir le booléeen ScoreHasUpdated qui vaut true dès que le score change dans update
    public GameObject whatToCall;
    public RuntimeAnimatorController newController;
    GameObject[] allPunch = new GameObject[1];
    private GameObject UppercutArrièreLent;
    void Awake()
    {
        anim.runtimeAnimatorController = newController;
        UppercutArrièreLent = Resources.Load<GameObject>("Sofia Animations/UppercutArrièreLent");
    }

    // Use this for initialization
    void Start()
    {
        allPunch[0] = UppercutArrièreLent;
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
    public void set_active()
    {
        anim.SetBool("active", true);
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
        if (whatToCall == UppercutArrièreLent)
        {
            anim.SetBool("DoUppercutArrièreLent", true);
        }
        anim.SetBool("active", false);
    }
    public GameObject return_whatToCall()
    {
        return (whatToCall);
    }
}










