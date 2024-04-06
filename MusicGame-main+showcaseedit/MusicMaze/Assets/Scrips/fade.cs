using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class fade : MonoBehaviour
{
    private new Renderer renderer;
    public double positionBPM;

    void Start()
    {

        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        GameObject playerObj = GameObject.Find("Player");
        Conductor conductorComp = playerObj.GetComponent<Conductor>();
        positionBPM = conductorComp.songPositionInBeats;

        // Check if the difference between positionBPM and its rounded value is within 0.3
        double difference = positionBPM - Math.Round(positionBPM);
        if (Mathf.Abs((float)difference) <= 0.3f)
        {
            renderer.enabled = true; // Render the object
        }
        else
        {
            renderer.enabled = false; // Hide the object
        }
    }
}
