using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    /*public int ContadorEnemigos = 5;
    public float tiempoParaSpawnear = 3;*/
    float delaySpawn;
    float delaySpawnYellow;
    float delaySpawnGreen;
    public PatronesEnemigo myEnemy;
    public PatronesEnemigo myEnemyYellow;
    public PatronesEnemigo myEnemyGreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            Spawn();
    }
    public void Spawn()
    {
        delaySpawn += Time.deltaTime;
        delaySpawnYellow += Time.deltaTime;
        delaySpawnGreen += Time.deltaTime;
        
        if(delaySpawn >= 3)
        {
            delaySpawn=0;
            PatronesEnemigo enemy = Instantiate(myEnemy, transform.position, transform.rotation);
            
        }
        if(delaySpawnYellow >= 7)
        {
            delaySpawnYellow=0;
            myEnemyYellow.esRegenerativo=true;
            PatronesEnemigo enemyYellow = Instantiate(myEnemyYellow, transform.position, transform.rotation);
            
        }
        if(delaySpawnGreen >= 11)
        {
            delaySpawnGreen=0;
            myEnemyGreen.esSaltador=true;
            PatronesEnemigo enemyGreen = Instantiate(myEnemyGreen, transform.position, transform.rotation);
            
        }
    }

    /*private IEnumerator spawnear(float tiempoParaSpawnear, GameObject Enemy)
    {
        yield return new WaitForSeconds(tiempoParaSpawnear);
        GameObject newEnemy = Instantiate(Enemy, new Vector3(GameObject))
    }*/
}
