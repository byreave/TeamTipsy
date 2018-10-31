using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Table"))
        {
            GetComponentInParent<AbsintheBottleControl>().GenerateASphere();
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Glass"))
        {
            GetComponentInParent<AbsintheBottleControl>().GenerateASphere();
            collision.gameObject.GetComponent<GlassControl>().DripCount++;
            Destroy(gameObject);
        }
    }
}
