using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDarah : MonoBehaviour
{
    public float valueDarah;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
                collision.GetComponent<darah>().tambahDarah(valueDarah);
                gameObject.SetActive(false);
            
            
        }
    }
}
