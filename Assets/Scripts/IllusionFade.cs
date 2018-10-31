using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionFade : MonoBehaviour {

    public bool isFading;
    public float alpha;
    public bool fadeOff;
	// Use this for initialization
	void Start () {
        isFading = true;
        alpha = 0.0f;
        gameObject.GetComponent<SpriteRenderer>().materials[0].color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, 1.0f);
        gameObject.GetComponent<SpriteRenderer>().materials[1].color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, 0.0f);

       
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log("Alpha: " + gameObject.GetComponent<SpriteRenderer>().color.a);
        if(isFading == true)
        {
            StartCoroutine(FadeTo(alpha, 1.0f, gameObject.GetComponent<SpriteRenderer>().materials[1]));
            isFading = false;
        }
        else
        {
            if(fadeOff == true)
            {
                gameObject.GetComponent<SpriteRenderer>().materials[0].color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, alpha);

            }
        }
        //gameObject.GetComponent<SpriteRenderer>().color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, alpha);

    }
    IEnumerator FadeTo(float aValue, float aTime, Material material)
    {

        float alpha = transform.GetComponent<SpriteRenderer>().materials[1].color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<SpriteRenderer>().materials[1].color = newColor;
            yield return null;
        }
    }
}
