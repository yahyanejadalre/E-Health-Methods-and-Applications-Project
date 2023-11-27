using System;
using UnityEngine;

public class RingSequence : MonoBehaviour
{
    public GameObject[] lightCircles;

    private void Start()
    {
        lightCircles[0] = GameObject.Find("LightRingScientist1");
        lightCircles[1] = GameObject.Find("LightRingCar");
        lightCircles[2] = GameObject.Find("LightRingInstruments");
    }
}

    