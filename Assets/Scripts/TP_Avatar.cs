using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Avatar : MonoBehaviour
{
    public GameObject Camera;
    public Transform avatar_transform;
    public Vector3 decal;
    public void TP_avatar()
    {
        Vector3 Offset = new Vector3(0.0f, avatar_transform.position[1], 0.0f);
        decal = 1.5f * Camera.transform.forward;
        decal[1] = 0;
        Vector3 camera_pos = Camera.GetComponent<Transform>().position;
        camera_pos[1] = avatar_transform.position[1];
        Vector3 camera_rot = new Vector3(0.0f, Camera.GetComponent<Transform>().rotation.eulerAngles[1], 0.0f);
        this.transform.SetPositionAndRotation(camera_pos + decal, Quaternion.Euler(camera_rot));
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
