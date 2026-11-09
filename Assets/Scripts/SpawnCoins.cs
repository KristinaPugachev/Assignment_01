using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public GameObject[] coinPrefabs;
    public int numberOfCoins = 5;
    
    public float minX = -50f;
    public float maxX = 50f;
    public float minY = -50f;
    public float maxY = 50f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnNewCoins();
    }
    
    private void SpawnCoin()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        int randomIndex = Random.Range(0, 3);
        
        Vector2 randomPosition = new Vector2(randomX, randomY);
        
        Instantiate(coinPrefabs[randomIndex], randomPosition, Quaternion.identity);
    }

    public void SpawnNewCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            SpawnCoin();
        }
    }
}
