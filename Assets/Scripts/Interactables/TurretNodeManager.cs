using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretNodeManager : MonoBehaviour
{

    //MeshRenderer nodeMesh;
    //BoxCollider nodeCollider;

    [SerializeField]
    public GameObject turretUI;

    [SerializeField]
    public InputManager inputManagerPlayer;

    [SerializeField]
    List<TurretNode> turretNodes = new List<TurretNode>();

    [SerializeField]
    public List<GameObject> turretObjects = new List<GameObject>();

    int TurretNodeNumber;

    int slotTurretNumber;

    //TurretNode turretNode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void SetTurretNodeNumber(int slotNodeNum)
    {
        // set for list numbers 0 to ... n
        //turretNodes[slotNodeNum].SetTurretNumber(slotNodeNum);

        TurretNodeNumber = slotNodeNum;
        //turretNodes[TurretNodeNumber].nodeMesh = GetComponent<MeshRenderer>();
        //turretNodes[TurretNodeNumber].nodeCollider = GetComponent<BoxCollider>();

    }

    public void SetTurretNumber(int slotNum)
    {
        // set for list numbers 0 to ... n
        slotTurretNumber = slotNum;

        Debug.Log("Interacted with " + slotNum);

    }

    public void UseTurretButton()
    {
        Debug.Log("Using Button");

        turretUI.SetActive(!turretUI.activeSelf);
        inputManagerPlayer.SetMouseLock(true);




        // Create Turret on Node
        GameObject prefabGameObject = Instantiate(
            turretObjects[slotTurretNumber],
            turretNodes[TurretNodeNumber].transform.position,
            Quaternion.identity,
            turretNodes[TurretNodeNumber].transform
            );
        prefabGameObject.name = "Turret Prefab";

        turretNodes[TurretNodeNumber].nodeMesh.enabled = false;
        turretNodes[TurretNodeNumber].nodeCollider.enabled = false;
    }

}
