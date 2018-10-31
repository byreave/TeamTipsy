using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsintheBottleControl : MonoBehaviour {

    public GameObject Sphere;
    [SerializeField]
    private int InitialSphereNumber = 10;
	// Use this for initialization
	void Start () {
		for(int i = 0 ; i < InitialSphereNumber ; ++ i)
        {
            GenerateASphere();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GenerateASphere()
    {
        Instantiate(Sphere, transform.position, Quaternion.identity, transform);
    }
}
