using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 50f;
    public Text CoinText;
    public Text winText;

    private float movement = 0f;
    private Rigidbody2D rigidBody;
    private int COIN;


    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        COIN = 0;
        SetCoinText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else if (movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Coins"))
        {
            collision2D.gameObject.SetActive(false);
            COIN = COIN + 1;
            SetCoinText();
        }
    }

    void SetCoinText ()
    {
        CoinText.text = "COIN: " + COIN.ToString();
        if (COIN >= 6)
        {
            winText.text = "HAPPY NEW YEAR TOMERS !";
        }
    }
}
