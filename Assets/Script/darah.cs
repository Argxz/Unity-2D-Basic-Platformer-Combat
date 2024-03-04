using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darah : MonoBehaviour
{
    // Start is called before the first frame update
    public float darahAwal;
    public float currentDarah;
    Animator anim;
    public bool mati;
    public static event Action playerMati;

    public void Awake()
    {
        currentDarah = darahAwal;
        anim = GetComponent<Animator>();
    }

    public void Diserang(float _damage)
    {
        currentDarah = Mathf.Clamp(currentDarah - _damage, 0, darahAwal);

        if (currentDarah > 0)
        {
            anim.SetTrigger("hit");
        }
        else
        {
            if (!mati)
            {
                anim.SetTrigger("mati");
                playerMati.Invoke();
                GetComponent<pemain>().enabled = false;
                mati = true;
            }
            
        }
    }

    public void tambahDarah(float _value)
    {
        currentDarah = Mathf.Clamp(currentDarah + _value, 0, darahAwal);
    }
}
