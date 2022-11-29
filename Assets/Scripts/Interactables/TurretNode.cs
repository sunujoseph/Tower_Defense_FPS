using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretNode : Interactable
{
    //[SerializeField] public GameObject turretObjectPrefab;

    MeshRenderer nodeMesh;
    BoxCollider nodeCollider;

    [SerializeField]
    public GameObject turretUI;

    [SerializeField]
    public InputManager inputManagerPlayer;

    [SerializeField]
    public List<GameObject> turretObjects = new List<GameObject>();

    int slotTurretNumber;

    // Start is called before the first frame update
    void Start()
    {
        nodeMesh = GetComponent<MeshRenderer>();
        nodeCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTurretNumber(int slotNum)
    {
        // set for list numbers 0 to ... n
        slotTurretNumber = slotNum;
    }

    public void UseTurretButton()
    {
        turretUI.SetActive(!turretUI.activeSelf);
        inputManagerPlayer.SetMouseLock(true);




        // Create Turret on Node
        GameObject prefabGameObject = Instantiate(
            turretObjects[slotTurretNumber],
            this.gameObject.transform.position,
            Quaternion.identity,
            transform
            );
        prefabGameObject.name = "Turret Prefab";

        nodeMesh.enabled = false;
        nodeCollider.enabled = false;
    }

    protected override void Interact()
    {
        // Code for Debugging
        Debug.Log("Interacted with " + gameObject.name);
        //GameObject newTurretGameObject = new GameObject("Turret Game Object");
        //newTurretGameObject.transform.position = this.gameObject.transform.position;
        //newTurretGameObject.transform.parent = transform;
        //GameObject prefabGameObject = Instantiate(turretObjectPrefab, this.gameObject.transform.position, Quaternion.identity, transform);
        //prefabGameObject.name = "Turret Prefab";

        turretUI.SetActive(!turretUI.activeSelf);

        inputManagerPlayer.SetMouseLock(false);

        //Cursor.lockState = CursorLockMode.None;






    }
}
