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
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("game started");
        SetScoreText();
        SetHealthText();
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
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            ResetPlayer();
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
            SetHealthText();
            // Debug.Log("Health: " + health);
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            // Debug.Log("You win!");
            Win();
        }
    }
    void SetScoreText(){
        scoreText.text = "Score:" + score;
    }
    void SetHealthText(){
        healthText.text = "Health: " + health;
    }
    
    void ResetPlayer(){
        score = 0;
        health = 0;
        SetHealthText();
        SetScoreText();
    }
    void Win(){
            winLoseBG.gameObject.SetActive(true);
            winLoseText.text = "You Win!";
            winLoseText.color = Color.black;
            winLoseBG.color = Color.green;
        }
    
}
