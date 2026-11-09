using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    Vector2 movement = Vector2.zero;

    private static string EnemyTag = "Enemy";
    static string CoinTag = "Coin";

    private int targetScore = 1000;
    private int currentScore = 0;

    public SpawnCoins coinSpawner;
    
    private int coinCounter = 0;

    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Target Score to win: " + targetScore);
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector2.zero;
        
        var dValue = Keyboard.current.dKey.value;
        var sValue = Keyboard.current.sKey.value;
        var aValue = Keyboard.current.aKey.value;
        var wValue = Keyboard.current.wKey.value;

        movement += dValue * Vector2.right;
        movement += aValue * Vector2.left;
        movement += sValue * Vector2.down;
        movement += wValue * Vector2.up;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Time.fixedDeltaTime * speed * movement);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(EnemyTag))
        {
            Debug.Log("you lose");
            EditorApplication.isPlaying = false;
        }

        if (other.CompareTag(CoinTag))
        {
            Coin coin = other.GetComponent<Coin>();
            currentScore += coin.scoreValue;
            Destroy(other.gameObject);
            coinCounter++;
            Debug.Log("Current Score: " + currentScore);

            if (currentScore >= targetScore)
            {
                Debug.Log("you won");
                EditorApplication.isPlaying = false;
            }
            if (coinCounter == 5)
            {
                coinCounter = 0;
                coinSpawner.SpawnNewCoins();
            }
        }
    }
    
}
