 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedScript : MonoBehaviour
{
    public int id;
    public PatientDataScript NPCData;
    [SerializeField] private PotionDataScript potionData;
    public GameObject glowObj;
    public bool haveSit;

    private bool haveMinigame;
    public Transform handPoint;
    [SerializeField] private GameObject minigameObj;
    [SerializeField] private miniGame minigame;
    private bool onMinigame;

    public int itemId;
    public int arrowAdd;
    public int treatTheSick;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Patient" && NPCData == null)
        {
            if (treatTheSick < 0)
            {
                AddPatient(other.gameObject);
            }//ถ้าต่ำกว่า 0 จะรักษาแบบไม่สนโรค
            else if (treatTheSick > 0)
            {
                if (treatTheSick == other.gameObject.GetComponent<PatientDataScript>().sicknessID)
                {
                    AddPatient(other.gameObject);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && onMinigame)
        {
            CloseMinigame();
        }
        if (other.tag == "Patient")
        {
            GameObject demo = other.gameObject;
            if (NPCData.id == demo.GetComponents<PatientDataScript>()[0].id)
            {
                RemovePiatent();
            }
        }
    }
    private void AddPatient(GameObject other)
    {
        NPCData = other.GetComponent<PatientDataScript>();
        if (!NPCData.dead)
        {
            NPCData.handPoint = handPoint;
            NPCData.onHand = true;
            NPCData.onBed = true;
            haveSit = true;

            minigame.difficulty = NPCData.sicknessLevel;
        }
    }
    private void Goodbye()
    {
        NPCData.sicknessID = -1;
        haveMinigame = false;
        minigame.difficulty = -1;
        haveSit = false;
        NPCData = null;
        minigame.ClearRhythm();
        CloseMinigame();
    }
    private void RemovePiatent()
    {
        haveMinigame = false;
        minigame.difficulty = -1;
        haveSit = false;
        NPCData = null;
        minigame.ClearRhythm();
    }
    public void PlayMinigame()
    {
        onMinigame = true;
        minigameObj.SetActive(true);
        if (NPCData != null && !haveMinigame )
        {
            haveMinigame = true;
            for (int i = 0; i < potionData.sicknessData[potionData.FindNumOfSick(NPCData.sicknessID)].patternPress.Length; i++)
            {
                minigame.intAllArrow.Add(potionData.sicknessData[potionData.FindNumOfSick(NPCData.sicknessID)].patternPress[i]);
            }
        }
    }
    public void CloseMinigame()
    {
        minigameObj.SetActive(false);
        onMinigame = false;
    }
    private void Start()
    {
        minigame.dataPotion = potionData;
        haveMinigame = false;
        haveSit = false;
        onMinigame = false;
        minigameObj.SetActive(false);

        itemId = 0;
        arrowAdd = 5;
        if (treatTheSick == 0)
        {
            Debug.Log("Add treatTheSick in bed " + id);
        }
    }
    private void Update()
    {
        if (NPCData != null)
        {
            if (!NPCData.onBed)
            {
                CloseMinigame();
            }
            NPCData.willTreat = (minigame.buttonPressed != 0) ? true : false;//กำลังรักษาอยู่หรือเปล่า
            if (treatTheSick > 0 && treatTheSick != NPCData.sicknessID)
            {
                RemovePiatent();
            }//เตียงไม่ตรงโรค
            else if (itemId == 99)
            {
                Goodbye();

                itemId = 0;
                Destroy(handPoint.GetChild(0).gameObject, 0);
                UIManagerScript.treated++;
            }//ยาวิเศษ
        }
        if (NPCData == null)
        {
            CloseMinigame();
            RemovePiatent();
        }
        if (minigame.difficulty == 0 && NPCData != null)
        {
            Goodbye();   
            if (itemId != 0)
            {
                itemId = 0;
                Destroy(handPoint.GetChild(0).gameObject, 0);
            }
                UIManagerScript.treated++;
            if (TextScript.textStart == 8 || TextScript.textStart == 9)
            {
                TextScript.textStart++;
            }
            else if (TextScript.textStart == 2 || TextScript.textStart == 3)
            {
                TextScript.textStart = 4;
            }
        }//เรื่องรักษา
        if (minigame.deHeat != 0 && NPCData != null)
        {
            if (NPCData.heat <= minigame.deHeat * -1)
            {
                NPCData.onHand = false;
                NPCData.onBed = false;
                NPCData.sicknessLevel = 1;
                NPCData.deHeat = minigame.deHeat;
                CloseMinigame();
                minigame.ClearRhythm();
                NPCData = null;
                haveSit = false;
                if (itemId != 0)
                {
                    itemId = 0;
                    Destroy(handPoint.GetChild(0).gameObject, 0);
                }
                RemovePiatent();
            }
            else
            {
                NPCData.deHeat = minigame.deHeat;
            }
            minigame.deHeat = 0;
        }//ได้รับความเสียหาย
        if (NPCData != null && minigame.difficulty != NPCData.sicknessLevel)
        {
            NPCData.sicknessLevel = minigame.difficulty;
        }
        if (arrowAdd != 5)
        {
            minigame.arrowAdd = arrowAdd;
            if (NPCData != null)
            {
                NPCData.animatorBunda.SetInteger("treat", arrowAdd);
            }
            arrowAdd = 5;
        }
    }
}
