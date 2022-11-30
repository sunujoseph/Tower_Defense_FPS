using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveUI : MonoBehaviour
{

    public Slider slider;

    private void Update()
    {
        slider.maxValue = PlayerStat.maxHealth;
        slider.value = PlayerStat.health;
        
    }


}
