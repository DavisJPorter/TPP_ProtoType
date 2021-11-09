using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightBattery : MonoBehaviour
{

    public GameObject battery;

    private bool trig = false;

    void OnTriggerEnter()
    {
        trig = true;
    }
    void Start()
    {
        trig = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (trig && Input.GetKeyDown(KeyCode.E))
        {
            FlashlightController flashlight = GameObject.FindGameObjectWithTag("Flashlight").gameObject.GetComponent<FlashlightController>();
            flashlight.batteryCount += 1;
            Destroy(battery);
        }
    }
}
