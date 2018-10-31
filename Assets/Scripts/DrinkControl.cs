using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkControl : MonoBehaviour
{

    // Use this for initialization
    public GameObject Player;
    public GameObject illusionGlass1;
    public GameObject illusionGlass2;
    public GameObject illusionGlass3;
    public GameObject illusionGlass4;
    public ParticleSystem greenParticle;
    public Camera mainCamera;

    private float drunkLevel;
    private SuperBlurBase sb;
    private float delayTimer;
    private bool hasTimerStarted;
    private bool increaseAlpha;
    //private IllusionFade illusion;




    private void Start()
    {
        drunkLevel = 0.0f;

        delayTimer = 0.0f;
        increaseAlpha = false;
        hasTimerStarted = false;

<<<<<<< HEAD
<<<<<<< HEAD
        //illusion = drinkingWall.GetComponent<IllusionFade>();
=======
=======
>>>>>>> 1796a546bedd99447e7ead80612d83f8126940f8
        sb = mainCamera.GetComponent<SuperBlurBase>();
        sb.interpolation = 0;
        sb.downsample = 0;

        illusion = drinkingWall.GetComponent<IllusionFade>();
>>>>>>> 1796a546bedd99447e7ead80612d83f8126940f8
        illusionGlass1.GetComponent<MeshRenderer>().enabled = false;
        illusionGlass2.GetComponent<MeshRenderer>().enabled = false;
        illusionGlass3.GetComponent<MeshRenderer>().enabled = false;
        illusionGlass4.GetComponent<MeshRenderer>().enabled = false;



    }

    private void Update()
    {
        //illusion.alpha = drunkLevel;

        if((drunkLevel >=1.0f))
        {
            sb.iterations = (int)drunkLevel;
        }

        if((drunkLevel >=1.0f))
        {
            sb.iterations = (int)drunkLevel;
        }

        if (hasTimerStarted == true)
        {
            delayTimer += Time.deltaTime;
            if ((int)delayTimer == 2)
            {
                increaseAlpha = true;
                hasTimerStarted = false;
                //illusion.fadeOff = true;

            }
        }

        if (increaseAlpha == true)
        {
            Debug.Log("Delay Timer is now activated!");
            drunkLevel -= 0.001f;
            if (drunkLevel <= 0.0f)
            {
                drunkLevel = 0.0f;
            }

            
        }

        if (drunkLevel >= 2.0f)
        {
            Debug.Log("Double Vision");

        }

        if(drunkLevel >=5.0)
        {
            Debug.Log("Game over");
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
                drunkLevel += 1.0f;
                sb.interpolation = 1;
                sb.downsample = 2;

<<<<<<< HEAD
                //illusion.alpha = drunkLevel;
=======
                illusion.alpha = drunkLevel;
                sb.iterations = (int)drunkLevel;
<<<<<<< HEAD
>>>>>>> 1796a546bedd99447e7ead80612d83f8126940f8
=======
>>>>>>> 1796a546bedd99447e7ead80612d83f8126940f8


                delayTimer = 0.0f;
                hasTimerStarted = true;
                increaseAlpha = false;
                //illusion.isFading = true;
                //illusion.fadeOff = false;

                //TO DO: Add the particle effect here!
                greenParticle.Play();
                


            }
        }

        if (other.CompareTag("Collider1") && drunkLevel >= 2.0f)
        {
            illusionGlass2.GetComponent<MeshRenderer>().enabled = true;
            illusionGlass3.GetComponent<MeshRenderer>().enabled = true;

        }

        if (other.CompareTag("Collider2") && drunkLevel >= 2.0f)
        {
            illusionGlass1.GetComponent<MeshRenderer>().enabled = true;
            illusionGlass4.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Collider1") && drunkLevel >= 2.0f)
        {
            illusionGlass2.GetComponent<MeshRenderer>().enabled = true;
            illusionGlass3.GetComponent<MeshRenderer>().enabled = true;

        }

        if (other.CompareTag("Collider2") && drunkLevel >= 2.0f)
        {
            illusionGlass1.GetComponent<MeshRenderer>().enabled = true;
            illusionGlass4.GetComponent<MeshRenderer>().enabled = true;
            illusionGlass2.GetComponent<MeshRenderer>().enabled = true;
            illusionGlass3.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collider1") && drunkLevel >= 2.0f)
        {
            illusionGlass2.GetComponent<MeshRenderer>().enabled = false;
            illusionGlass3.GetComponent<MeshRenderer>().enabled = false;

        }

        if (other.CompareTag("Collider2") && drunkLevel >= 2.0f)
        {
            illusionGlass1.GetComponent<MeshRenderer>().enabled = false;
            illusionGlass4.GetComponent<MeshRenderer>().enabled = false;

        }
    }
}
