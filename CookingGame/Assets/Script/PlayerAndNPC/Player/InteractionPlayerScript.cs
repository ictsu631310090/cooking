using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlayerScript : MonoBehaviour
{
    public static List<int> tableInteraction = new List<int>();//สำหรับโต้ะและเครื่องต่างๆ

    public static int itemInHand = 0;//ของในมือ
    public static bool haveItem = false;
    public static bool[] havePlate = new bool[] { false, false };
    public ShowModelScript showModel;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    Debug.Log("havePlate : " + havePlate[0] + "," + havePlate[1]);
        //}
        showModel.ShowModel(itemInHand, havePlate[0], havePlate[1]);
        if (Input.GetKeyDown(KeyCode.E) && tableInteraction.Count >= 2)
        {
            tableInteraction.Add(tableInteraction[0]);
            tableInteraction.RemoveAt(0); 
        }//สลับโต็ะที่เล็ง
    }
}