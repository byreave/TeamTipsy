using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
public class DrinkControl : MonoBehaviour
{
    // Use this for initialization
    public GameObject Player;
    public GameObject Walls;
    public GameObject illusionGlass1;
    public GameObject illusionGlass2;
    public GameObject illusionGlass3;
    public GameObject illusionGlass4;
    public ParticleSystem greenParticle;
    private PostProcessingProfile ppp;
    [SerializeField]
    private float DrunkFadeDelayTime = 2.0f;
    [SerializeField]
    private float DrunkFadeSpeed = 0.1f;
    [SerializeField]
    private float IllusionDrunkLevel = 2.0f;
    [SerializeField]
    private float BlackoutDrunkLevel = 5.0f;
    [SerializeField]
    private float MotionBlurDrunkLevel = 4.0f;
    [SerializeField]
    private float VignetteDrunkLevel = 3.0f;
    //public Camera mainCamera;
    private float drunkLevel;
    //private SuperBlurBase sb;
    private float delayTimer;
    private bool hasTimerStarted;
    private bool increaseAlpha;
    //private IllusionFade illusion;
    private void Start()
    {
        ppp = Camera.main.GetComponent<PostProcessingBehaviour>().profile;
        
        drunkLevel = 0.0f;
        delayTimer = 0.0f;
        increaseAlpha = false;
        hasTimerStarted = false;
        //sb = mainCamera.GetComponent<SuperBlurBase>();
        //sb.interpolation = 0;
        //sb.downsample = 0;
      //  illusion = drinkingWall.GetComponent<IllusionFade>();
        illusionGlass1.GetComponent<MeshRenderer>().enabled = false;
        illusionGlass2.GetComponent<MeshRenderer>().enabled = false;
        illusionGlass3.GetComponent<MeshRenderer>().enabled = false;
        illusionGlass4.GetComponent<MeshRenderer>().enabled = false;
    }
    private void Update()
    {
        var MotionBlurSetting = ppp.motionBlur.settings;
        
        var VignetteSetting = ppp.vignette.settings;
        VignetteSetting.mode = VignetteModel.Mode.Masked;

        if (drunkLevel >= VignetteDrunkLevel)
            VignetteSetting.opacity = drunkLevel / BlackoutDrunkLevel;
        else
            VignetteSetting.opacity = 0.0f;
        MotionBlurSetting.frameBlending = drunkLevel / MotionBlurDrunkLevel;

        ppp.motionBlur.settings = MotionBlurSetting;
        ppp.vignette.settings = VignetteSetting;

        if(VignetteSetting.opacity >=0.99f)
        {
            VignetteSetting.opacity = 0.99f;
        }
       // illusion.alpha = drunkLevel;
        if (( drunkLevel >= 1.0f ))
        {
            //sb.iterations = (int)drunkLevel;
        }
        if (hasTimerStarted == true)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= DrunkFadeDelayTime)
            {
                increaseAlpha = true;
                hasTimerStarted = false;
                //illusion.fadeOff = true;
            }
        }

        if (increaseAlpha == true)
        {
            Debug.Log("Delay Timer is now activated!");
            if(drunkLevel >= 0)
                drunkLevel -= DrunkFadeSpeed * Time.deltaTime;

        }
        if (drunkLevel >= IllusionDrunkLevel)
        {
            Debug.Log("Double Vision");
        }
        if (drunkLevel >= BlackoutDrunkLevel)
        {
            drunkLevel = BlackoutDrunkLevel;

            Debug.Log("Game over");
        }
        //set walls drunk level
        Walls.GetComponent<WallFadeControl>().DrunkLevel = drunkLevel;
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
                //sb.interpolation = 1;
                //sb.downsample = 2;
                //illusion.alpha = drunkLevel;
                //sb.iterations = (int)drunkLevel;
                delayTimer = 0.0f;
                hasTimerStarted = true;
                increaseAlpha = false;
                //illusion.isFading = true;
                //illusion.fadeOff = false;
                //TO DO: Add the particle effect here!
                greenParticle.Play();

            }
        }
        if (other.CompareTag("Collider1") && drunkLevel >= IllusionDrunkLevel)
        {
            illusionGlass2.GetComponent<MeshRenderer>().enabled = true;
            illusionGlass3.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.CompareTag("Collider2") && drunkLevel >= IllusionDrunkLevel)
        {
            illusionGlass1.GetComponent<MeshRenderer>().enabled = true;
            illusionGlass4.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Collider1") && drunkLevel >= IllusionDrunkLevel)
        {
            illusionGlass2.GetComponent<MeshRenderer>().enabled = true;
            illusionGlass3.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.CompareTag("Collider2") && drunkLevel >= IllusionDrunkLevel)
        {
            illusionGlass1.GetComponent<MeshRenderer>().enabled = true;
            illusionGlass4.GetComponent<MeshRenderer>().enabled = true;
            illusionGlass2.GetComponent<MeshRenderer>().enabled = true;
            illusionGlass3.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collider1") && drunkLevel >= IllusionDrunkLevel)
        {
            illusionGlass2.GetComponent<MeshRenderer>().enabled = false;
            illusionGlass3.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.CompareTag("Collider2") && drunkLevel >= IllusionDrunkLevel)
        {
            illusionGlass1.GetComponent<MeshRenderer>().enabled = false;
            illusionGlass4.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}