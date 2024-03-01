using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialthrow : MonoBehaviour
{
    public void ButtomClose()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    private void FixedUpdate()
    {
        Time.timeScale = 0;
    }
}
