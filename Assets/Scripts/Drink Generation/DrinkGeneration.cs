using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkGeneration : MonoBehaviour {

    public GameObject[] Drinks;
    public float GenerationTime = 3.0f;

    private float counter;
	// Use this for initialization
	void Start () {
        counter = GenerationTime = 3.1f;
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
		if(counter > GenerationTime)
        {
            int genIndex = Random.Range(0, Drinks.Length);
            Instantiate(Drinks[genIndex], this.transform.position, Quaternion.identity);
            counter = 0.0f;
        }
	}

}
