using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Slider flashlightPower;
    [SerializeField] private Image flashlightBar;
    public Light flashlight;

    public float power = 100.0f;
    private float maxPower = 100.0f;
    private float minPower = 0.0f;

    private float batteryCharge = 100.0f;
    public int batteryCount = 3;
    public int powerDrain = 1;
    private bool usable = true;

    private void Start()
    {
        flashlight.enabled = false;
    }
    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.R) && batteryCharge >= 0)
        {
            power += batteryCharge;
            batteryCount -= 1;
        }
        if (batteryCount <= 0)
        {
            batteryCount = 0;
        }

        flashlightPower.value = power;
    }
}
