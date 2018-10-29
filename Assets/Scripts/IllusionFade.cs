﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionFade : MonoBehaviour {

    public bool isFading;
    public float alpha;
    public bool fadeOff;
	// Use this for initialization
	void Start () {
        isFading = false;
        alpha = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Alpha: " + gameObject.GetComponent<SpriteRenderer>().color.a);
        if(isFading == true)
        {
            StartCoroutine(FadeTo(alpha, 1.0f));
            isFading = false;
        }
        else
        {
            if(fadeOff == true)
            {
                StartCoroutine(FadeTo(1.0f, 2.0f));
            }
        }
        //gameObject.GetComponent<SpriteRenderer>().color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, alpha);

    }
    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<SpriteRenderer>().material.color = newColor;
            yield return null;
        }
    }
}