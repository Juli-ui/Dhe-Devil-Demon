using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int movementSpeed=5;
    float lifeTime;
    public bool esSnipper;
    public bool esExplosiva;
    public Explosion explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if(esSnipper==false)
        {
            if(lifeTime >= 0.5)
                Destroy(gameObject);
            transform.position += transform.up * movementSpeed * Time.deltaTime;
        }
        if (esSnipper == true)
        {
            if(lifeTime >= 6)
                Destroy(gameObject);
            transform.position += transform.up * movementSpeed * Time.deltaTime;
        }
        if (esExplosiva == true)
        {
            if (lifeTime >= 1.5)
            {
                //Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            transform.position += transform.up * movementSpeed * Time.deltaTime;
        }

    }
}
