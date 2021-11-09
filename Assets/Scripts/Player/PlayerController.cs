using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public LayerMask groundLayers;
    public float jumpForce = 7;
    public SphereCollider col;

    private Rigidbody rb;
    private int count;
    private float MovementX;
    private float MovementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();

        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementvalue)
    {
        Vector2 movementvector = movementvalue.Get<Vector2>();

        MovementX = movementvector.x;
        MovementY = movementvector.y;
    }

    void SetCountText()
    {
        countText.text = "Collectibles: " + count.ToString();
        if(count >= 100)
        {
            winTextObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {

        Vector3 Movement = new Vector3(MovementX, 0.0f, MovementY);

        rb.AddForce(Movement * speed);

    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
}
