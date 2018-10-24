using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkControl : MonoBehaviour {

    // Use this for initialization
    public GameObject Player;
    public GameObject alternateWorld;
    public GameObject weirdWorld;

    private FadeWhitebox fd;
    private FadeWhitebox fd1;
    private float drunkLevel;
    private float otherLevel;

    private void Start()
    {
        fd = alternateWorld.GetComponent<FadeWhitebox>();
        fd1 = weirdWorld.GetComponent<FadeWhitebox>();

        otherLevel = 0.0f;
        fd1.alphaLevel = otherLevel;
        drunkLevel = 1.0f;
        fd.alphaLevel = drunkLevel;

    }

    private void Update()
    {

        if (fd.alphaLevel <= 1.0f)
        {
            fd.alphaLevel += 0.002f;

        }
    }
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Drink"))
        {
            Player.GetComponent<DrunkBarControl>().DrunkLevel += 30;
            other.gameObject.SetActive(false);
       

            fd.alphaLevel -= 0.3f;
            fd1.alphaLevel += 0.4f;

        }

    }
}
