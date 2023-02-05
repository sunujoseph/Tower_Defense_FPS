using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGrade : MonoBehaviour
{
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject camera2;
    [SerializeField] GameObject camera3;
    [SerializeField] GameObject mainCamera;

    private void Start()
    {
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(false);
        camera3.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            camera1.gameObject.SetActive(true);
            camera2.gameObject.SetActive(false);
            camera3.gameObject.SetActive(false);

            mainCamera.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            camera2.gameObject.SetActive(true);
            camera1.gameObject.SetActive(false);
            camera3.gameObject.SetActive(false);

            mainCamera.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            camera3.gameObject.SetActive(true);
            camera2.gameObject.SetActive(false);
            camera1.gameObject.SetActive(false);

            mainCamera.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(false);
            camera3.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
        }
    }

}
