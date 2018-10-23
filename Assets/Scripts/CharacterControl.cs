using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class CharacterControl : MonoBehaviour {

    // Use this for initialization
    private Vector3 OriginalPos;
	void Start () {
        OriginalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position.Set(0.0f, 0.0f, 0.0f);
	}
}
