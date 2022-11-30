using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static int health;
    public static int maxHealth; 


    public int startHealth = 50;


    private void Start()
    {
        health = startHealth;
        maxHealth = startHealth;
    }

}
