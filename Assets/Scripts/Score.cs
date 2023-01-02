using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public ScoreSO ScoreSO;
    double score;
    public TMP_Text scoretext;
    public void display_score_function()
    {
        score = ScoreSO.score;
        scoretext.text = ScoreSO.score.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
