using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightLight : MonoBehaviour
{
    [Tooltip("If true, the light will be active during the day. If false, the light will become active at night.")]
    public bool dayCycleLight;
    public float fadeDuration = 5;
    private Light lightComponent;
    void Start()
    {
        if (gameObject.GetComponent<Light>() != null)
            lightComponent = gameObject.GetComponent<Light>();
        else
            Debug.Log("No Light Component found on gameObject.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
