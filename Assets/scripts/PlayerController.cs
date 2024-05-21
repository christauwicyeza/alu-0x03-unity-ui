using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class PlayerController : MonoBehaviour
{
    public float speed = 50f;
    private Rigidbody rb;
    private int score = 0;
    public int health = 5;
    public Text scoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("game started");
        SetScoreText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        rb.AddForce(new Vector3(horizontalMove, 0.0f, verticalMove) * (speed * Time.deltaTime));
    }

    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            // Debug.Log("Score: " + score);
            other.gameObject.SetActive(false);
            SetScoreText();
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }
    void SetScoreText(){
        scoreText.text = "Score:" + score;
    }
}
