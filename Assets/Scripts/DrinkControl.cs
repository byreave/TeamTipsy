using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkControl : MonoBehaviour {

    // Use this for initialization
    public GameObject Player;
    public GameObject alternateWorld;

    private FadeWhitebox fd;
    private float drunkLevel;

    private void Start()
    {
        fd = alternateWorld.GetComponent<FadeWhitebox>();
        drunkLevel = 1.0f;
    }

    private void Update()
    {
        fd.alphaLevel = drunkLevel;
        if(drunkLevel <=1.0f)
        {
            drunkLevel += 0.0001f;

        }
    }
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Drink"))
        {
            Player.GetComponent<DrunkBarControl>().DrunkLevel += 30;
            other.gameObject.SetActive(false);
            Destroy(gameObject);
            Debug.Log("HERE");
        

            drunkLevel -= 0.35f;

        }

    }
}
