using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaSpawnearSnipers : MonoBehaviour
{
    float delaySpawn;
    public EnemySnipper myEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnSniper();
    }
    public void SpawnSniper()
    {
        delaySpawn += Time.deltaTime;
        if(delaySpawn >= 10)
        {
            delaySpawn=0;
            EnemySnipper enemy = Instantiate(myEnemy, transform.position, transform.rotation);
            
        }
    }
}
