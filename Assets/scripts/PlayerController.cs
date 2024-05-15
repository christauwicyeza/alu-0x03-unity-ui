using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        rb.AddForce(new Vector3(horizontalMove, 0.0f, verticalMove) * (speed * Time.deltaTime)); 
    }
}
