using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceAlpha : MonoBehaviour {


    public float alpha;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(gameObject.GetComponent<MeshRenderer>().material.color.r, gameObject.GetComponent<MeshRenderer>().material.color.g, gameObject.GetComponent<MeshRenderer>().material.color.b,alpha);
		
	}
}
