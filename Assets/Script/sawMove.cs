using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawMove : MonoBehaviour
{
    public float damage;
    public float jarakGerak;
    public float speed;
    bool gerakKiri;
    float leftEdge;
    float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - jarakGerak;
        rightEdge = transform.position.x + jarakGerak;
    }
    private void Update()
    {
        if (gerakKiri)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position
                    .y, transform.position.z);
            }
            else
            {
                gerakKiri = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position
                    .y, transform.position.z);
            }
            else
            {
                gerakKiri = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<darah>().Diserang(damage);
        }
            
    }
}
