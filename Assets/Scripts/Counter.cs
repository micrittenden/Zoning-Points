using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Counter : MonoBehaviour
{
    private GameManager gameManager;
    
    public int zoneValue;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Set bounciness of the prefab ball to 0 when it passes into the zone areas
        other.gameObject.GetComponent<Collider>().material.bounciness = 0;
        other.gameObject.GetComponent<Collider>().material.bounceCombine = PhysicMaterialCombine.Minimum;

        // Add to the score based on the value of the zone which the prefab ball landed in
        gameManager.UpdateScore(zoneValue);
        //Debug.Log("You scored " + zoneValue + " points.");    
    }
}
