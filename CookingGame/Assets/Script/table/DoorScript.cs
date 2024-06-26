using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private PotionDataScript doorCooldown;
    private ToolPlayerScript playerData;
    [SerializeField] private Transform whatGo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (doorCooldown.cooldownDoor <= 0)
            {
                playerData = other.gameObject.GetComponent<ToolPlayerScript>();
                doorCooldown.cooldownDoor = doorCooldown.cooldownDoorMax;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (doorCooldown.cooldownDoor <= 0)
            {
                playerData = other.gameObject.GetComponent<ToolPlayerScript>();
                doorCooldown.cooldownDoor = doorCooldown.cooldownDoorMax;
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
    }
    private void Update()
    {
        if (playerData != null)
        {
            MovePlayer();
        }
    }
}
