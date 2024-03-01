using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    private ToolPlayerScript playerData;
    [SerializeField] private float cooldown;
    private float cooldownMax;
    [SerializeField] private Transform whatGo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (cooldown <= 0)
            {
                playerData = other.gameObject.GetComponent<ToolPlayerScript>();
                cooldown = cooldownMax;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (cooldown <= 0)
            {
                playerData = other.gameObject.GetComponent<ToolPlayerScript>();
                cooldown = cooldownMax;
            }
        }
    }
    private void MovePlayer()
    {
        playerData.gameObject.transform.position = new Vector3(whatGo.position.x, playerData.gameObject.transform.position.y, whatGo.position.z);

        if (playerData != null)
        {
            if (playerData.havePatient)
            {
                playerData.patientID[0].heat = 0;
            }
        }
        playerData = null;
    }
    private void Start()
    {
        if (whatGo == null)
        {
            Debug.LogError("put data whatGo");
        }
        cooldownMax = cooldown;
    }
    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (playerData != null)
        {
            MovePlayer();
        }
    }
}
