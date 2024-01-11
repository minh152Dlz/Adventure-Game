using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public GameObject playerPrefab;  
    public Transform playerClone;  
    public bool check;
    public GameObject stalk;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {   
            if(check){
                if(gameObject.GetComponent<ItemCollector>().ruby == 1)
                {
                    gameObject.GetComponent<ItemCollector>().ruby = 0;
                    PlayerController prefabMovement = playerPrefab.GetComponent<PlayerController>();
                    prefabMovement.enabled = false;
                    playerClone.gameObject.SetActive(true);
                    playerClone.GetComponent<PlayerController>().enabled = true;
                    playerClone.position = stalk.transform.position;
                }
            }
            else
            {
                gameObject.GetComponent<PlayerController>().enabled = false;
                playerPrefab.GetComponent<PlayerController>().enabled = true;
            }
        }
    }
}

