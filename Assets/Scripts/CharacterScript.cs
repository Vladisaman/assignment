using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] private TMP_Text CoinsText;
    [SerializeField] private TMP_Text CoinsTextLosePanel;
    public int Coins;
    [SerializeField] private Sprite explosion;

    [SerializeField] private GameObject LosePanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = Vector2.zero;
    }

    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");

        if ((rb.transform.localScale.x > 0 && moveDirection.x < 0) || (rb.transform.localScale.x < 0 && moveDirection.x > 0))
        {
            rb.transform.localScale = new Vector2(-1 * rb.transform.localScale.x, rb.transform.localScale.y);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Coins++;
            Destroy(collision.gameObject);
            UpdateCoins();
        }

        if (collision.CompareTag("Bomb"))
        {
            Lose(collision.GetComponent<SpriteRenderer>());
        }
    }

    private void UpdateCoins()
    {
        CoinsText.text = Coins.ToString();
    }

    private void Lose(SpriteRenderer Bomb)
    {
        Bomb.sprite = explosion;
        Time.timeScale = 0;
        GetComponent<SpriteRenderer>().enabled = false;
        LosePanel.SetActive(true);
        CoinsTextLosePanel.text = Coins.ToString();
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}