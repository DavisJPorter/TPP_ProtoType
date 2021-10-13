using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public TextMeshProUGUI batteryLifeText;
    public Light flashlight;

    public float power = 100;
    private float maxPower = 100;
    private float minPower = 0;

    private float batteryCharge = 100.0f;
    public int batteryCount = 3;
    public int powerDrain = 1;
    private bool usable = true;

    void Update()
    {
        batteryLifeText.text = power + "%";
        if (Input.GetKeyDown(KeyCode.F) && usable)
        {
            flashlight.enabled = !flashlight.enabled;
        }
        if (flashlight.enabled)
        {
           power -= Time.deltaTime * powerDrain;
            
        }
        if (power > maxPower)
        {
            power = maxPower;
        }
        if (power < minPower)
        {
            power = minPower;
            flashlight.enabled = false;
            usable = false;
        }
        if (power > minPower)
        {
            usable = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && batteryCharge > 0)
        {
            power += batteryCharge;
            batteryCount -= 1;
        }

    }
}
