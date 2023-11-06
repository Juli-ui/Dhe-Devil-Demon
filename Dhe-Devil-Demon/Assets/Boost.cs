using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public NewBehaviourScript Torrets;
    public NewBehaviourScript Torrets2;
    public NewBehaviourScript Torrets3;
    static float BoostTime = 3;
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
        BoostTime += Time.deltaTime;
        //Debug.Log("BoostTime: " + BoostTime);
        if (BoostTime>=3)
        {
            Torrets.delayShoots = 0.5f;
            Torrets2.delayShoots = 0.5f;
            Torrets3.delayShoots = 0.5f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bala" || other.gameObject.tag == "BalaSnipper")
        {
            BoostTime = 0f;
            Torrets.delayShoots = 0.1f;
            Torrets2.delayShoots = 0.1f;
            Torrets3.delayShoots = 0.1f;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
