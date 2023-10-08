using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public bool twoPlayer;

    public GameObject[] playerP;
    public Transform[] spawnPoint;
    private GameObject[] player = new GameObject[2];
    private void Spawn(int x)
    {
        switch (x)
        {
            case 1:
                player[0] = Instantiate(playerP[0], spawnPoint[0], false);
                player[0].transform.parent = null;
                break;
            case 2:
                player[0] = Instantiate(playerP[0], spawnPoint[1], false);
                player[1] = Instantiate(playerP[1], spawnPoint[2], false);
                player[0].transform.parent = null;
                player[1].transform.parent = null;
                break;
            default:
                if (!twoPlayer)
                {
                    player[0] = Instantiate(playerP[0], spawnPoint[0], false);
                    player[0].transform.parent = null;
                }
                else
                {
                    player[0] = Instantiate(playerP[0], spawnPoint[1], false);
                    player[1] = Instantiate(playerP[1], spawnPoint[2], false);
                    player[0].transform.parent = null;
                    player[1].transform.parent = null;
                }
                break;
        }
    }
    private void Start()
    {
        Spawn(UIManagerScript.numOfPlayer);
    }
    private void Update()
    {
        
    }
}