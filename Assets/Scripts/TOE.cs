using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class TOE : MonoBehaviour
{   
    public bool active;
    public Animator anim;
    public GameObject Player;
    public GameObject Hand_1;
    public GameObject Hand_2;
    public GameObject Head_1;
    List<Vector3> List_LHand_ref = new List<Vector3>();
    List<Vector3> List_Rhand_ref = new List<Vector3>();
    List<Vector3> List_Head_ref = new List<Vector3>();
    List<Vector3> List_LHand_player = new List<Vector3>();
    List<Vector3> List_Rhand_player = new List<Vector3>();
    List<Vector3> List_Head_player = new List<Vector3>();
    public GameObject Right_Hand;
    public GameObject Left_Hand;
    public GameObject Head;
    GameObject g;
    Transform transforme;
    Transform LHand_ref ;
    Transform RHand_ref;
    Transform Head_ref;
    Transform Right_Hplayer;
    Transform Left_Hplayer;
    Transform Head_player;
    Vector3 Vector;
    public UnityEvent display_score_function;
    public UnityEvent ChangePunch;
    public UnityEvent ChangeEsquive;
    double score = 0;
    double refscore = 0;
    public ScoreSO Score_SO;
    float duration;
    public TP_Avatar tp_avatar;
    Vector3 decal;
    
     public void setactive()
    {
        active = true;
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        ChangePunch?.Invoke();
        ChangeEsquive?.Invoke();
    }

        public void Compute_Score()
    {
        int taille = List_LHand_ref.Count;
        decal = tp_avatar.decal;
        /*
        score = 1;
        int taille = List_LHand_ref.Count;
        for (int i = 0; i < taille; i++)
        {
            Vector3 LHand_ref = List_LHand_ref[i];
            Vector3 LHand_player = List_LHand_player[i];
            Vector3 RHand_ref = List_Rhand_ref[i];
            Vector3 RHand_player = List_Rhand_player[i];
            Vector3 Head_ref = List_Head_ref[i];
            Vector3 Head_player = List_Head_player[i];
            float Compar_LHand = Vector3.Dot(LHand_ref, LHand_player) / (LHand_ref.magnitude * LHand_player.magnitude);
            float Compar_RHand = Vector3.Dot(RHand_ref, RHand_player) / (RHand_ref.magnitude * RHand_player.magnitude);
            float Compar_Head = Vector3.Dot(Head_ref, Head_player) / (Head_ref.magnitude * Head_player.magnitude);
            score *= Compar_LHand;
            score *= Compar_Head;
            score *= Compar_RHand;
        }
        */

        //good old score

        score =0;
        for (int i = 0; i < taille; i++)
        {
            score += (List_LHand_player[i] - List_LHand_ref[i] + decal).sqrMagnitude;
            score += (List_Rhand_player[i] - List_Rhand_ref[i] + decal).sqrMagnitude;
            score += (List_Head_player[i] - List_Head_ref[i] + decal).sqrMagnitude;

            /*
            for (int j = 0; j < 3; j++)
            {
                double vect = Convert.ToSingle(List_LHand_ref[i][j] - List_LHand_player[i][j]);
                score += Math.Pow(vect,2);
                vect = Convert.ToSingle(List_Rhand_ref[i][j] - List_Rhand_player[i][j]);
                score += Math.Pow(vect, 2);
                vect = Convert.ToSingle(List_Head_ref[i][j] - List_Head_player[i][j]);
                score += Math.Pow(vect, 2);
            };
            */
        }
        score = score * 100;
        score = score / taille;


        /*
        score = 0;
        refscore = 0;
        for (int i = 0; i < taille; i++)
        {
            refscore += (List_LHand_ref[i] - List_LHand_ref[0]).sqrMagnitude;
            refscore += (List_Rhand_ref[i] - List_Rhand_ref[0]).sqrMagnitude;
            refscore += (List_Head_ref[i] - List_Head_ref[0]).sqrMagnitude;

            score += (List_LHand_player[i] - List_LHand_ref[i]).sqrMagnitude;
            score += (List_Rhand_player[i] - List_Rhand_ref[i]).sqrMagnitude;
            score += (List_Head_player[i] - List_Head_ref[i]).sqrMagnitude;
        }

        score = Mathf.Abs(refscore - score) / refscore * 100;
        
        */

        Score_SO.score = (float)Math.Round(score);
        display_score_function?.Invoke();
        ChangePunch?.Invoke();
        ChangeEsquive?.Invoke();
        Clear_lists();
        active = false;
    }
    void Clear_lists()
    {
     List_LHand_ref = new List<Vector3>();
      List_Rhand_ref = new List<Vector3>();
     List_Head_ref = new List<Vector3>();
        List_LHand_player = new List<Vector3>();
         List_Rhand_player = new List<Vector3>();
        List_Head_player = new List<Vector3>();

    }
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            duration = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;

            LHand_ref = Hand_1.transform;
            Vector = LHand_ref.position;
            List_LHand_ref.Add(Vector);

            RHand_ref = Hand_2.transform;
            Vector = RHand_ref.position;
            List_Rhand_ref.Add(Vector);
            //g.transform.position = RHand_ref.position;

            Head_ref = Head_1.transform;
            Vector = Head_ref.position;
            List_Head_ref.Add(Vector);
            //g.transform.position = Head_ref.position;

            Right_Hplayer = Right_Hand.transform;
            Vector = Right_Hplayer.position;
            List_Rhand_player.Add(Vector);
            //g.transform.position = Right_Hplayer.position;

            Left_Hplayer = Left_Hand.transform;
            Vector = Left_Hplayer.position;
            List_LHand_player.Add(Vector);

            Head_player = Head.transform;
            Vector = Head_player.position;
            List_Head_player.Add(Vector);
            //g.transform.position = Head_player.position;

            if (duration > 0.99) { Compute_Score(); }
        }
        
    }
}
