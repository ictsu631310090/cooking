 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedScript : MonoBehaviour
{
    public int id;
    //public ShowInjury injury;
    [SerializeField] private PatientDataScript NPCData;
    [SerializeField] private PotionDataScript potionData;
    [SerializeField] private GameObject glowObj;
    public bool haveSit;
    private bool haveMinigame;
    public GameObject handPoint;
    [SerializeField] private GameObject minigameObj;
    [SerializeField] private Not2Rhythm minigame;
    private bool onMinigame;

    [SerializeField] private GameObject bedDirtyModel;
    [SerializeField] private float timeCheck;
    [SerializeField] private bool bedDirty;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !bedDirty)
        {
            glowObj.SetActive(true);
            ToolPlayerScript.bed.Add(this);
        }
        if (other.tag == "Patient" && !bedDirty)
        {
            NPCData = other.gameObject.GetComponent<PatientDataScript>();
            //injury.ShowItemWant(NPCData.sicknessID);
            haveSit = true;
            minigame.difficulty = NPCData.sicknessLevel;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !onMinigame)
        {
            glowObj.SetActive(false);
            ToolPlayerScript.bed.Remove(this);
        }
        else if (other.gameObject.tag == "Player" && onMinigame)
        {
            //if (NPCData != null)
            //{
            //    injury.ShowItemWant(NPCData.sicknessID);
            //}
            CloseMinigame();
            glowObj.SetActive(false);
            ToolPlayerScript.bed.Remove(this);
        }
        if (other.tag == "Patient")
        {
            RemovePiatent();
        }
    }
    private void DebutAllEnum()
    {
        Debug.Log("id Bed : " + id);
        Debug.Log("NPCData : " + NPCData);
        Debug.Log("haveSit : " + haveSit);
        Debug.Log("onMinigame : " + onMinigame);
        Debug.Log("bedDirty : " + bedDirty);
        Debug.Log("~~~~~~~~~~~~~~~~~~~~");
    }
    private void Goodbye()
    {
        NPCData.sicknessID = -1;
        minigame.difficulty = -1;
        haveSit = false;
        NPCData = null;
        CloseMinigame();
    }
    private void RemovePiatent()
    {
        minigame.difficulty = -1;
        NPCData = null;
        haveSit = false;
        haveMinigame = false;
        minigame.ClearRhythm();
    }
    private void PlayMinigame()
    {
        onMinigame = true;
        minigameObj.SetActive(true);
        if (NPCData != null && !haveMinigame)
        {
            haveMinigame = true;
            for (int i = 0; i < potionData.sicknessData[potionData.FindNumOfSick(NPCData.sicknessID)].patternPress.Length; i++)
            {
                minigame.intAllArrow.Add(potionData.sicknessData[potionData.FindNumOfSick(NPCData.sicknessID)].patternPress[i]);
            }
        }
    }
    private void CloseMinigame()
    {
        minigameObj.SetActive(false);
        ////CameraScript.zoomOut = true;
        onMinigame = false;
    }
    private void Start()
    {
        haveMinigame = false;
        haveSit = false;
        onMinigame = false;
        minigameObj.SetActive(false);

        bedDirtyModel.SetActive(false);
        bedDirty = false;
        timeCheck = 0;
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    DebutAllEnum();
        //}
        if (bedDirty)
        {
            timeCheck += Time.deltaTime;
            bedDirtyModel.SetActive(true);
            if (timeCheck >= potionData.timeBedDirty)
            {
                timeCheck = 0;
                bedDirty = false;
                bedDirtyModel.SetActive(false);
            }
        }
        if (NPCData != null)
        {
            NPCData.willTreat = (minigame.buttonPressed != 0) ? true : false;
            if (NPCData.dead)
            {
                bedDirty = true;
                Destroy(NPCData.gameObject, 0);
                RemovePiatent();
            }
        }
        if (NPCData == null)
        {
            RemovePiatent();
        }

        if (ToolPlayerScript.bed.Count > 0)
        {
            if (id == ToolPlayerScript.bed[0].id && NPCData != null)
            {
                glowObj.SetActive(true);
                if (haveSit)
                {
                    PlayMinigame();
                    //injury.CloseImage();
                }
            }
        }
        else if (ToolPlayerScript.bed.Count == 0)
        {
            CloseMinigame();
            glowObj.SetActive(false);
        }
        if (minigame.difficulty == 0 && NPCData != null)
        {
            Goodbye();
            UIManagerScript.treated++;
        }
        if (minigame.deHeat != 0 && NPCData != null)
        {
            if (NPCData.heat <= minigame.deHeat * -1)
            {
                NPCData.deHeat = minigame.deHeat;
                NPCData = null;
                minigame.ClearRhythm();
                haveSit = false;
                bedDirty = true;
            }
            else
            {
                NPCData.deHeat = minigame.deHeat;
            }
            minigame.deHeat = 0;
        }
        if (NPCData != null && minigame.difficulty != NPCData.sicknessLevel)
        {
            NPCData.sicknessLevel = minigame.difficulty;
        }
    }
}
