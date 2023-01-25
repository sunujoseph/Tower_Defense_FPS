using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health = 10; 
    public float MaxHealth= 10;


    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "fallzone")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        if (col.gameObject.tag == "Enemy" || col.gameObject.name == "Enemy")
        {
            health = health - 1;
            Debug.Log("Owch!" + health + "health remaining");

        }

    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.name == "Enemy")
        {
            health = health - 1;
            Debug.Log("Owch!" + health + "health remaining");
        }
    }


}
