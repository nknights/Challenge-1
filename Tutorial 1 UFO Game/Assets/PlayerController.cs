using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Text countText;

    public Text WinText;

    public Text LivesText;

    private Rigidbody2D rb2d;

    private int count;

    private int lives;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        count = 0;

        lives = 3;

        WinText.text = "";

        SetCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }



    }


    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag("PickUp"))
            {

                other.gameObject.SetActive (false);

            count = count + 1;

            SetCountText();

            }
            else if (other.gameObject.CompareTag("Enemy"))
            {

                 other.gameObject.SetActive(false);

            lives = lives - 1;

            SetCountText();


            }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 12)
        {
            transform.position = new Vector2(-28.4f, 52.3f);
        }
        if (count >= 20)
        {
            WinText.text = "You Win";
        }
        LivesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            WinText.text = "Game Over";

          
                Destroy(gameObject);
         

        }
    }

}
