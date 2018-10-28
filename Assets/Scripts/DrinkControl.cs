using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkControl : MonoBehaviour {

    // Use this for initialization
    public GameObject Player;

    
    private float drunkLevel;

    private float delayTimer;
    private bool hasTimerStarted;
    private bool increaseAlpha;
    

    private void Start()
    {
        drunkLevel = 0.0f;

        delayTimer = 0.0f;
        increaseAlpha = false;
        hasTimerStarted = false;

    }

    private void Update()
    {
       
        if(hasTimerStarted == true)
        {
            delayTimer += Time.deltaTime;
            if((int)delayTimer == 3)
            {
                increaseAlpha = true;
                hasTimerStarted = false;
            }
        }

        if(increaseAlpha == true)
        {
            drunkLevel += 0.001f;
            Debug.Log("Drunk Level" + drunkLevel);
            if(drunkLevel >= 1.0f)
            {
                drunkLevel = 1.0f;
            }
        }
        
    }
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Glass"))
        {
            if (other.gameObject.GetComponent<GlassControl>().FillLevel > 0)
            {
                other.gameObject.GetComponent<GlassControl>().FillLevel--;
                //to do: Increase the drunk level here.
                drunkLevel += 0.2f;
                delayTimer = 0.0f;
                hasTimerStarted = true;
                increaseAlpha = false;
            }
        }
    }
 
    private void OnTriggerStay(Collider other)
    {
        //if drunk, the glass's water level should be reduced.
       /* if (other.CompareTag("Glass"))
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
        }*/
    }
}
