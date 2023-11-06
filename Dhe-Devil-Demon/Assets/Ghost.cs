using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public bool irSalida = false;
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private Transform target;
    private SpriteRenderer spriteRenderer;
    Color color;
    public float contadorParaSalir;
    // Start is called before the first frame update
    void Start()
    {
        target = pointB;
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        contadorParaSalir += Time.deltaTime;
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        if (irSalida)
        {
            target = pointB;
            
            color.a = 0.5f;
            spriteRenderer.color = color;
        }
        else
        {
            target = pointA;
            color.a = 1f;
            spriteRenderer.color = color;
        }
        if(contadorParaSalir>=10)
        {
            irSalida = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bala")
        {
            contadorParaSalir = 0;
            irSalida = false;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BalaSnipper")
        {
            contadorParaSalir = 0;
            irSalida = false;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "PointA")
        {
            contadorParaSalir = 0;
            irSalida = false;
        }
    }
}
