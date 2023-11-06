using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsLimit : MonoBehaviour
{
    public GameObject powerUpBoost;
    public GameObject powerUpHeal;
    public float generationIntervalBoost = 10f;
    public float generationIntervalHeal = 10f;
    public Vector2 spawnAreaSize = new Vector2(10f, 10f);

    private void Start()
    {
        InvokeRepeating("GeneratePowerUpBoost", 0f, generationIntervalBoost);
        InvokeRepeating("GeneratePowerUpHeal", 0f, generationIntervalHeal);
    }

    private void GeneratePowerUpBoost()
    {
        float randomX = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        float randomY = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);

        Vector3 spawnPositionBoost = new Vector3(transform.position.x + randomX, transform.position.y + randomY, 0f);
        
        Instantiate(powerUpBoost, spawnPositionBoost, Quaternion.identity);
        
    }
    private void GeneratePowerUpHeal()
    {
        float randomX = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        float randomY = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);

        
        Vector3 spawnPositionHeal = new Vector3(transform.position.x + randomX, transform.position.y + randomY, 0f);
        
        Instantiate(powerUpHeal, spawnPositionHeal, Quaternion.identity);
    }
}
