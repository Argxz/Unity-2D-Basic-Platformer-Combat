using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class darahbar : MonoBehaviour
{
    public darah playerDarah;
    public Image totalbarDarah;
    public Image barDarahCurrent;

    private void Start()
    {
        totalbarDarah.fillAmount = playerDarah.currentDarah / 10;
    }

    private void Update()
    {
        barDarahCurrent.fillAmount = playerDarah.currentDarah / 10;
    }
}
