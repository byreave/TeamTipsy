using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class CharacterControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var interactionSourceStates = InteractionManager.GetCurrentReading();
        //this.transform.Translate(interactionSourceState);
        foreach (var interSourceState in interactionSourceStates)
        {
            //if(interSourceState.thumbstickPosition)
            //interSourceState.
            Debug.Log(interSourceState.thumbstickPosition);
        }
	}
}
