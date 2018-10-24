using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateControl : MonoBehaviour {

    [SerializeField]
    private bool RightToLeft = true;
    [SerializeField]
    private float speed = 0.2f;

    private bool OnMove = false;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
        //rb.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(OnMove)
        {
            if (RightToLeft)
                rb.velocity = new Vector3(speed, 0, 0);
            else
                rb.velocity = new Vector3(-speed, 0, 0);
        }    

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (OnMove == false && collision.gameObject.CompareTag("Drink"))
        {
            OnMove = true;
        }
        if(collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
