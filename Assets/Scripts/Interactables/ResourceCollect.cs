using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceCollect : MonoBehaviour
{
    public int wood;
    public int gold;
    public TextMeshProUGUI woodCounter;
    public TextMeshProUGUI goldCounter;

    // Update is called once per frame
    void Update()
    {
        woodCounter.text = wood.ToString();
        goldCounter.text = gold.ToString();
    }

    public void OnTriggerEnter(Collider Col) // very simple, can update to other resources later
    {
        if (Col.gameObject.tag == "Wood")
        {
            Debug.Log("Collected Wood!");
            wood += 1;
            Col.gameObject.SetActive(false);
        }
        if (Col.gameObject.tag == "Gold")
        {
            Debug.Log("Collected Gold!");
            gold += 1;
            Col.gameObject.SetActive(false);
        }
    }
}
