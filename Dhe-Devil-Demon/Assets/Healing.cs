using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public NewBehaviourScript Torrets;
    public NewBehaviourScript Torrets2;
    public NewBehaviourScript Torrets3;
    // Start is called before the first frame update
    void Start()
    {
        Torrets = GameObject.Find("Torre").GetComponent<NewBehaviourScript>();
        Torrets2 = GameObject.Find("Torre (1)").GetComponent<NewBehaviourScript>();
        Torrets3 = GameObject.Find("Torre (2)").GetComponent<NewBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bala" || other.gameObject.tag == "BalaSnipper")
        {
            if(Torrets.vida < 4 && Torrets.vida >0)
                Torrets.vida += 1;
            if (Torrets2.vida < 4 && Torrets2.vida > 0)
                Torrets2.vida += 1;
            if (Torrets3.vida < 4 && Torrets3.vida > 0)
                Torrets3.vida += 1;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
