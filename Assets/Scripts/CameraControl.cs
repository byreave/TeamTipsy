using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    // Use this for initialization
    private Vector3 OriginalPos;
    void Start()
    {
        OriginalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = OriginalPos;
    }
}
