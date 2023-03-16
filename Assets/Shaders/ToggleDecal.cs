using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ToggleDecal : MonoBehaviour
{
    public Material mat;
    bool showDecal = false;

    void OnMouseDown()
    {
        showDecal = !showDecal;
        if (showDecal)
        {
            mat.SetFloat("_ShowDecal", 1);
        }
        else
        {
            mat.SetFloat("_ShowDecal", 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mat = this.GetComponent<Renderer>().sharedMaterial;
    }

}