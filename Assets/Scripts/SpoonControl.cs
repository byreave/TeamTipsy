using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonControl : MonoBehaviour {
    [SerializeField]
    private int DripCount = 0;
    [SerializeField]
    private int DripToMelt = 5;
    [SerializeField]
    private GameObject SugarCubeMelt1;
    [SerializeField]
    private GameObject SugarCubeMelt2;
    [SerializeField]
    private GameObject SugarCubeMelt3;

    public GameObject GrabbableSpoon;
    public GameObject Glass;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(DripCount > DripToMelt && SugarCubeMelt1.activeSelf)
        {
            SugarCubeMelt1.SetActive(false);
            SugarCubeMelt2.SetActive(true);
        }
        else if(DripCount > DripToMelt * 2 && SugarCubeMelt2.activeSelf)
        {
            SugarCubeMelt2.SetActive(false);
            SugarCubeMelt3.SetActive(true);
        }
        else if (DripCount > DripToMelt * 3 && SugarCubeMelt3.activeSelf)
        {
            SugarCubeMelt3.SetActive(false);
            DripCount = 0;
            //to do: instanstiate a grabbable spoon here
            Instantiate(GrabbableSpoon, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("asdfdsfsassss");
        Debug.Log(other.name);

        if (SugarCubeMelt1.activeSelf || SugarCubeMelt2.activeSelf || SugarCubeMelt3.activeSelf)
        {
            Debug.Log("!!!");
            DripCount++;
            Glass.GetComponent<GlassControl>().DripCount++;
        }
    }
    private void OnParticleTrigger()
    {
        Debug.Log("asdfdsf");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sugar"))
        {
            Destroy(other.gameObject);
            SugarCubeMelt1.SetActive(true);
        }
    }

}
