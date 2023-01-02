using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject fbxtotrack;
    public GameObject prefabToInstantiate;
    GameObject g;
    Transform transforme;
    void CreateObject()
    {
        transform.position = new Vector3(0, 0, 0);
        g = Instantiate(prefabToInstantiate, transforme);

    }

    // Start is called before the first frame update
    void Start()
    {

        CreateObject();
    }
    // Update is called once per frame
    void Update()
    {
        Transform fbx;
        fbx = fbxtotrack.transform;
        Vector3 Vector = fbx.position;
        print(Vector);
        g.transform.position = fbx.position;
    }
}

