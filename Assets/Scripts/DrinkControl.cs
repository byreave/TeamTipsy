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

    private float timer;
    private bool hasTimerStarted;
    private bool increaseAlpha;
    

    private void Start()
    {
        fd = alternateWorld.GetComponent<FadeWhitebox>();
        fd1 = weirdWorld.GetComponent<FadeWhitebox>();

        otherLevel = 0.0f;
        fd1.alphaLevel = otherLevel;
        drunkLevel = 1.0f;
        fd.alphaLevel = drunkLevel;

        timer = 0.0f;
        increaseAlpha = false;
        hasTimerStarted = false;

    }

    private void Update()
    {

        if (increaseAlpha == true)
        {
            if (fd.alphaLevel <= 1.0f)
            {
                fd.alphaLevel += 0.002f;

            }
        }

        if(hasTimerStarted == true)
        {

            //Debug.Log()
            timer += Time.deltaTime;
            if((int) timer == 3)
            {
                increaseAlpha = true;
                hasTimerStarted = false;
            }
        }

        if(fd.alphaLevel == 1.0f)
        {
            increaseAlpha = false;
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

            timer = 0.0f;
            hasTimerStarted = true;

        }

    }
    private void OnTriggerStay(Collider other)
    {
        //if drunk, the glass's water level should be reduced.
        if (other.CompareTag("Glass"))
        {
            //currently don't rotate.
            //if(other.gameObject.transform.rotation.x > 0.75f || other.gameObject.transform.rotation.x < -0.75f)
            {
                if(other.gameObject.GetComponent<GlassControl>().FillLevel > 0)
                {
                    other.gameObject.GetComponent<GlassControl>().FillLevel--;
                    //to do: Increase the drunk level here.
                }
            }
        }
    }
}
