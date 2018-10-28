using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkControl : MonoBehaviour {

    // Use this for initialization
    public GameObject Player;

    
    private float drunkLevel;

    private float timer;
    private bool hasTimerStarted;
    private bool increaseAlpha;
    

    private void Start()
    {
        drunkLevel = 1.0f;

        timer = 0.0f;
        increaseAlpha = false;
        hasTimerStarted = false;

    }

    private void Update()
    {
       
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
        
    }
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drink"))
        {
            Player.GetComponent<DrunkBarControl>().DrunkLevel += 30;

            timer = 0.0f;
            hasTimerStarted = true;

        }

        if (other.CompareTag("Glass"))
        {
            if (other.gameObject.GetComponent<GlassControl>().FillLevel > 0)
            {
                other.gameObject.GetComponent<GlassControl>().FillLevel--;
                //to do: Increase the drunk level here.

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
