using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceCollect : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI coinCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinCounter.text = "Coins: " + coins;
    }

    public void OnTriggerEnter(Collider Col) // very simple, can update to other resources later
    {
        if (Col.gameObject.tag == "Coin")
        {
            Debug.Log("Collected!");
            coins += 1;
            Col.gameObject.SetActive(false);
        }
    }
}
