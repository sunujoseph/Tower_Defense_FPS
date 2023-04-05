using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurretNodeManager : MonoBehaviour
{

    //MeshRenderer nodeMesh;
    //BoxCollider nodeCollider;

    [SerializeField]
    public GameObject turretUI;

    [SerializeField]
    public InputManager inputManagerPlayer;

    [SerializeField]
    public ResourceCollect resourceCollect;

    [SerializeField]
    List<TurretNode> turretNodes = new List<TurretNode>();

    [SerializeField]
    public List<GameObject> turretObjects = new List<GameObject>();

    int TurretNodeNumber;

    int slotTurretNumber;

    int[] turretWoodCost = new int[3];
    int[] turretGoldCost = new int[3];

    int currentPlayerWood;
    int currentPlayerGold;

    bool playerCanBuild = false;

    //TurretNode turretNode;

    // Start is called before the first frame update
    void Start()
    {
        // can set turret cost here
        turretWoodCost[0] = 3;
        turretGoldCost[0] = 1;

        turretWoodCost[1] = 2;
        turretGoldCost[1] = 2;

        turretWoodCost[2] = 1;
        turretGoldCost[2] = 3;

        turretUI.transform.Find("Turret 1 Cost").GetComponent<TMP_Text>().text = turretWoodCost[0] + " wood & " + turretGoldCost[0] + " Gold"; // format: "3 wood & 1 Gold"
        turretUI.transform.Find("Turret 2 Cost").GetComponent<TMP_Text>().text = turretWoodCost[1] + " wood & " + turretGoldCost[1] + " Gold";
        turretUI.transform.Find("Turret 3 Cost").GetComponent<TMP_Text>().text = turretWoodCost[2] + " wood & " + turretGoldCost[2] + " Gold";
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

        currentPlayerWood = resourceCollect.wood;
        currentPlayerGold = resourceCollect.gold;

        //turretUI.transform.Find("Error Turret").GetComponent<TMP_Text>().text = " Welcome";

        //check if player have the required resources for turret
        if (currentPlayerWood >= turretWoodCost[slotTurretNumber] && currentPlayerGold >= turretGoldCost[slotTurretNumber])
        {
            playerCanBuild = true;
            resourceCollect.decreaseResource(turretWoodCost[slotTurretNumber], turretGoldCost[slotTurretNumber]);

        }
        else
        {
            playerCanBuild = false;
        }

    }

    public void UseTurretButton()
    {
        //turretUI.transform.Find("Error Turret").GetComponent<TMP_Text>().text = " ";

        //check if player can build turret.
        //turretUI.transform.Find("Error Turret").GetComponent<TMP_Text>().text = " Welcome";
        if (playerCanBuild == true)
        {

            Debug.Log("Using Button");

            turretUI.SetActive(!turretUI.activeSelf);
            inputManagerPlayer.SetMouseLock(true);
            inputManagerPlayer.SetUsingTurretNode(true);




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

            inputManagerPlayer.SetUsingTurretNode(false);

            playerCanBuild = false;

            turretUI.transform.Find("Error Turret").GetComponent<TMP_Text>().text = " ";
        }
        else
        {
            // tell player they need more resources
            Debug.Log("Need more resources to build turret");
            turretUI.transform.Find("Error Turret").GetComponent<TMP_Text>().text = "Need More Resources!";



        }



        
    }

    public void UseTurretCloseButton()
    {

        //Close menu 

        turretUI.SetActive(!turretUI.activeSelf);
        inputManagerPlayer.SetMouseLock(true);
        inputManagerPlayer.SetUsingTurretNode(true);

        inputManagerPlayer.SetUsingTurretNode(false);

        playerCanBuild = false;

        turretUI.transform.Find("Error Turret").GetComponent<TMP_Text>().text = " ";

    }

}
