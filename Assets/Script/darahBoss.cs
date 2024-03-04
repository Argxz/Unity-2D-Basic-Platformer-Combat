using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darahBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public float darahAwal;
    public float currentDarah;
    Animator anim;
    public bool mati;

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
                GetComponent<bossMove>().enabled = false;
                mati = true;
            }

        }
    }
}
