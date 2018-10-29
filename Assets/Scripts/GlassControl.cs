using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassControl : MonoBehaviour {

    public GameObject MySpoon;
    public GameObject SpoonToGrab;
    public int FillLevel = 0;
    public int DripCount = 0;
    [SerializeField]
    private int DripToFill = 10;
    [SerializeField]
    private GameObject WaterLevel1;
    [SerializeField]
    private GameObject WaterLevel2;
    [SerializeField]
    private GameObject WaterLevel3;
    bool ReadyToAttachSpoon = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(DripCount >= DripToFill)
        {
            if(FillLevel < 3)
                FillLevel++;
            DripCount -= DripToFill;
        }
        if (!WaterLevel1.activeSelf && FillLevel == 1)
            WaterLevel1.SetActive(true);
        else if (WaterLevel1.activeSelf && FillLevel != 1)
            WaterLevel1.SetActive(false);
        if (!WaterLevel2.activeSelf && FillLevel == 2)
            WaterLevel2.SetActive(true);
        else if (WaterLevel2.activeSelf && FillLevel != 2)
            WaterLevel2.SetActive(false);
        if (!WaterLevel3.activeSelf && FillLevel == 3)
            WaterLevel3.SetActive(true);
        else if (WaterLevel3.activeSelf && FillLevel != 3)
            WaterLevel3.SetActive(false);
        if(FillLevel == 3 && MySpoon.activeSelf)
        {
            MySpoon.GetComponent<SpoonControl>().DripCount = 0;
            MySpoon.GetComponent<SpoonControl>().SugarCubeMelt3.SetActive(false);
            MySpoon.SetActive(false);
            Instantiate(SpoonToGrab, MySpoon.transform.position, MySpoon.transform.rotation);
            ReadyToAttachSpoon = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spoon") && ReadyToAttachSpoon)
        {
            Destroy(collision.gameObject);
            MySpoon.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spoon"))
        {
            ReadyToAttachSpoon = true;
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        DripCount++;
    }
}
