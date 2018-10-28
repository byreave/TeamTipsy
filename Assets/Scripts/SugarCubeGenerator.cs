using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarCubeGenerator : MonoBehaviour {

    public GameObject SugarCube;
    public Transform Position;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Sugar"))
        {
            Instantiate(SugarCube, Position.position, Quaternion.identity, transform);
        }
    }
}
