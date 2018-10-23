using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour {

    // Use this for initialization
    private Component[] renderers;
	void Start () {
        renderers = this.GetComponentsInChildren<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        foreach(MeshRenderer r in renderers)
        {
            r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, 0.1f);
        }
		
	}
}
