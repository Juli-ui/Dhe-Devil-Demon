using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnipper : MonoBehaviour
{
    public Bala myBala;
    float delayDisparo=0;
    float vida =2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delayDisparo += Time.deltaTime;
        if(delayDisparo>=3)
        {
            Shoot();
            //Debug.Log("Dispara");
            delayDisparo=0;
        }   
        
    }
    void Shoot()
    {
        Vector3 shootDirection;
        shootDirection.x =6;
        shootDirection.y=-4;
        shootDirection.z = 0;
        Bala bullet = Instantiate(myBala, transform.position, transform.rotation);
        bullet.transform.up = shootDirection-transform.position; 
        //Debug.Log("SaleBala");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "BalaSnipper")
        {
            vida-=3;
            if(vida<=0)
            {
                Destroy(gameObject);
                Debug.Log("MurioElEnemigoSniper");
            }
            Destroy(other.gameObject);
        }
    }
    
}
