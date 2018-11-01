using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBottle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Instantiate(gameObject, new Vector3(-0.4f, -0.3f, -2.6f), Quaternion.identity);
        }
    }
}
