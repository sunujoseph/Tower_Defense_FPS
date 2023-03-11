using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] Camera warm;
    [SerializeField] Camera cold;
    [SerializeField] Camera custom;
    [SerializeField] Camera main;

    private void Start()
    {
        main.gameObject.SetActive(true);
        warm.gameObject.SetActive(false);
        cold.gameObject.SetActive(false);
        custom.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            main.gameObject.SetActive(false);
            warm.gameObject.SetActive(true);
            cold.gameObject.SetActive(false);
            custom.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            main.gameObject.SetActive(false);
            warm.gameObject.SetActive(false);
            cold.gameObject.SetActive(true);
            custom.gameObject.SetActive(false);
        }
       if (Input.GetKeyDown(KeyCode.P))
        {
            main.gameObject.SetActive(false);
            warm.gameObject.SetActive(false);
            cold.gameObject.SetActive(false);
            custom.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            main.gameObject.SetActive(true);
            warm.gameObject.SetActive(false);
            cold.gameObject.SetActive(false);
            custom.gameObject.SetActive(false);
        }
    }
}
