using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrunkBarControl : MonoBehaviour {

    public float DrunkLevel = 0.0f;
    [SerializeField]
    private Slider DrunkSlider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DrunkSlider.value = DrunkLevel;
	}
}
