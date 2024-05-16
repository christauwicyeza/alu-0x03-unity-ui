using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50f;
    private Rigidbody rb;
    private int score = 0;
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
        Debug.Log("game started");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        rb.AddForce(new Vector3(horizontalMove, 0.0f, verticalMove) * (speed * Time.deltaTime)); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++; // Increment the score
            Debug.Log("Score: " + score);
            other.gameObject.SetActive(false);
        }
    }
}