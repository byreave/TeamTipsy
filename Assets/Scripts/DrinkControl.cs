using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkControl : MonoBehaviour {

    // Use this for initialization
    public GameObject Player;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Drink"))
        {
            Player.GetComponent<DrunkBarControl>().DrunkLevel += 30;
            other.gameObject.SetActive(false);
        }

    }
}
