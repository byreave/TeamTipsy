using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeWhitebox : MonoBehaviour {


    int children;

    private Component[] renderers;

    public float alphaLevel;
    // Use this for initialization
    void Start () {
        children = transform.childCount;
        renderers = gameObject.GetComponentsInChildren<MeshRenderer>();

        //alphaLevel = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        foreach(MeshRenderer child in renderers)
        {
            //child.material.color = new Color(child.material.color.r,child.material.color.g,child.material.color.b,alphaLevel);
        }
		
	}
}
