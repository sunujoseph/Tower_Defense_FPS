using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private float distance = 3f;

    [SerializeField]
    private LayerMask mask;

    private PlayerUI playerUI;
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // clear prompt message if not looking at interactable
        playerUI.UpdatePromptText(string.Empty);

        // create a ray line from the center of camera outwards
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, distance, mask)) 
        {

            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                // For Debugging purposes
                //Debug.Log(hitInfo.collider.GetComponent<Interactable>().promptMessage);

                Interactable currentInteractable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdatePromptText(currentInteractable.promptMessage);

                // Player press E Button
                if (inputManager.onFoot.Interact.triggered)
                {
                    currentInteractable.BaseInteract();
                }
            }
        }
    }
}
