using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f;
    
    public Rigidbody2D playerRb;
    private Rigidbody2D enemyRb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (playerRb != null)
        {
            Vector2 direction = (playerRb.position - enemyRb.position).normalized;
            Vector2 newPosition = enemyRb.position + direction * (speed * Time.fixedDeltaTime);
            enemyRb.MovePosition(newPosition);
        }
    }
}

