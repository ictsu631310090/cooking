using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewIngredientScript : MonoBehaviour
{
    public ItemData[] itemData;

    public MixFood[] mixFood;
    public float timeUseAuto;
    public float timeUseManuel;

    public int FindNumOfArray(int id)
    {
        int j = 0;
        for (j = 0; j < itemData.Length; j++)
        {
            if (itemData[j].id == id)
            {
                break;
            }
        }
        return j;
    }

    [System.Serializable]
    public class MixFood
    {
        public int[] mixfood;
        public int food;
    }
}
