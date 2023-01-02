using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offset_menu : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Player;
    public Vector3 offset_manual;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        Vector3 position = Camera.GetComponent<Transform>().position;
        Vector3 pos_player = Player.transform.position;
        offset = position - pos_player;
        Debug.Log(position);
        Debug.Log(pos_player);
        this.transform.SetPositionAndRotation(pos_player-offset+offset_manual, this.transform.rotation);
    }
}

