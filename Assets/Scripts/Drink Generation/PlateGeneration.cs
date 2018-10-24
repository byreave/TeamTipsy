using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateGeneration : MonoBehaviour {

    public GameObject PlatePrefab;
    public float GenerationTime = 3.0f;

    float counter;
	// Use this for initialization
	void Start () {
        counter = GenerationTime = 3.1f;
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
		if(counter > GenerationTime)
        {
            Instantiate(PlatePrefab, this.transform.position, Quaternion.identity);
            counter = 0.0f;
        }
	}
}
