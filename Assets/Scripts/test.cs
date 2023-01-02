using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    public float speed;
    public float speed_decrease;
    private int coup_choisi;
    private float final_rot = 0.0f;
    private float rot_current = 0.0f;
    private bool is_clicked = false;
    private float time_sleep = 0.0f;

    public void BtnClick() {
    coup_choisi = Random.Range(1, 7);
    final_rot = 360*3 + (coup_choisi-1) * 60;
    is_clicked = true;
    }



    private void Update() {
        if(rot_current < final_rot) {
            rot_current = rot_current + speed * Time.deltaTime;
            this.transform.Rotate(0, 0, speed * Time.deltaTime, Space.Self);
            if (rot_current > final_rot - 360f){
                speed = speed * speed_decrease;
            }
        }
        else if(is_clicked == true) {
            time_sleep = time_sleep + Time.deltaTime;
            if (time_sleep > 1f){
                SceneManager.LoadScene(coup_choisi);
            }
        }
    }
}
