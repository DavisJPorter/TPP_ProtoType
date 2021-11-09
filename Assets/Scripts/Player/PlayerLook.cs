using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDATE
{



public class PlayerLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;


            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
}
