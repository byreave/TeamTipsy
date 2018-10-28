using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionFade : MonoBehaviour {

    public bool isFading;
	// Use this for initialization
	void Start () {
        isFading = false;		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Alpha: " + gameObject.GetComponent<SpriteRenderer>().color.a);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);

    }
}
