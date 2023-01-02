using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s_LoadSceneFromMenu : MonoBehaviour
{
    public void LoadLevel(string levelName){
        //load the game scene
        SceneManager.LoadSceneAsync(levelName); //0 = Main Menu, 1 = Game Scene
    }
}
