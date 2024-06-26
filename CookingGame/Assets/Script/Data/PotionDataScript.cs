 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionDataScript : MonoBehaviour
{
    public CreateSicknessScript[] sicknessData;
    public int dieLimit;
    public float timeDelayInput;
    public int buttonPressed;
    public float cooldownDoor;
    [HideInInspector] public float cooldownDoorMax;
    [HideInInspector] public SoundPlayerScript sound;
    public int FindNumOfSick(int id)
    {
        int j = 0;
        for (j = 0; j < sicknessData.Length; j++)
        {
            if (sicknessData[j].id == id)
            {
                break;
            }
        }
        return j;
    }
    private void Start()
    {
        sound = GetComponent<SoundPlayerScript>();
        cooldownDoorMax = cooldownDoor;
        UIManagerScript.dieLimit = dieLimit;
    }
    private void Update()
    {
        if (cooldownDoor >= -1)
        {
            cooldownDoor -= Time.deltaTime;
        }
    }
}
