using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSelector : MonoBehaviour
{

    [SerializeField] Material[] materials;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rend.material = materials[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rend.material = materials[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            rend.material = materials[2];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            rend.material = materials[3];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            rend.material = materials[4];
        }
    }
}
