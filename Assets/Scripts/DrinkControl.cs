using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkControl : MonoBehaviour {

    // Use this for initialization
    public GameObject Player;
    public GameObject drinkingWall;
    public GameObject fiftyGlass;
    public GameObject sevenFiveGlass;
    
    private float drunkLevel;

    private float delayTimer;
    private bool hasTimerStarted;
    private bool increaseAlpha;
    private IllusionFade illusion;
    

    private void Start()
    {
        drunkLevel = 0.0f;

        delayTimer = 0.0f;
        increaseAlpha = false;
        hasTimerStarted = false;

        illusion = drinkingWall.GetComponent<IllusionFade>();



    }

    private void Update()
    {
        illusion.alpha = drunkLevel;
        if(hasTimerStarted == true)
        {
            delayTimer += Time.deltaTime;
            if((int)delayTimer == 3)
            {
                increaseAlpha = true;
                hasTimerStarted = false;
                illusion.fadeOff = true;

            }
        }

        if(increaseAlpha == true)
        {
            illusion.isFading = true;
            illusion.fadeOff = false;
            drunkLevel -= 0.001f;
            Debug.Log("Drunk Level" + drunkLevel);
            if(drunkLevel <= 0.0f)
            {
                drunkLevel = 0.0f;
            }
        }
        if (drunkLevel >= 0.75)
        {
            fiftyGlass.GetComponent<MeshRenderer>().enabled = true;
            fiftyGlass.GetComponent<BoxCollider>().enabled = true;

            sevenFiveGlass.GetComponent<MeshRenderer>().enabled = true;
            sevenFiveGlass.GetComponent<BoxCollider>().enabled = true;

        }
        else
        {
            fiftyGlass.GetComponent<MeshRenderer>().enabled = false;
            fiftyGlass.GetComponent<BoxCollider>().enabled = false;

            sevenFiveGlass.GetComponent<MeshRenderer>().enabled = false;
            sevenFiveGlass.GetComponent<BoxCollider>().enabled = false;
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
                drunkLevel += 0.3f;
                delayTimer = 0.0f;
                hasTimerStarted = true;
                increaseAlpha = false;
                illusion.isFading = false;


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
