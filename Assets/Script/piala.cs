using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piala : MonoBehaviour
{
    public static event Action playerMenang;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerMenang.Invoke();
            Destroy(GameObject.FindWithTag("Player"));
        }

    }
}
