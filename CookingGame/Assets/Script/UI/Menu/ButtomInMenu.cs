using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtomInMenu : MonoBehaviour
{
    [SerializeField] private GameObject playUI;
    [SerializeField] private GameObject buttomContinue;
    [SerializeField] private GameObject continueUI;
    [SerializeField] private GameObject cerditUI;
    [SerializeField] private GameObject[] dayButtom;
    public void PlayButtom()
    {
        playUI.SetActive(true);
    }
    public void OnePlayerButtom()
    {
        UIManagerScript.numOfPlayer = 1;
        CutScene();
    }
    public void TwoPlayerButtom()
    {
        UIManagerScript.numOfPlayer = 2;
        CutScene();
    }
    private void CutScene()
    {
        SceneManager.LoadScene("CutScene1");
    }
    public void GoToTuTorialDayButtom()
    {
        SceneManager.LoadScene("TuDay");
    }
    public void GoToDayOneButtom()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToDayTwoButtom()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToDayThreeButtom()
    {
        SceneManager.LoadScene(3);
    }
    public void OpenContinueUI()
    {
        continueUI.SetActive(true);
    }
    public void CloseUI()
    {
        playUI.SetActive(false);
        continueUI.SetActive(false);
        cerditUI.SetActive(false);
    }
    public void ExitButtom()
    {
        Application.Quit();
    }
    private void InputCode()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.U))
            {
                PlayerPrefs.SetInt("Day", 4);
                CheckDay();
            }
        }
        else if (Input.GetKey(KeyCode.Backspace))
        {
            PlayerPrefs.SetInt("Day", 0);
            CheckDay();
        }
    }
    private void CheckDay()
    {
        if (buttomContinue != null)
        {
            buttomContinue.SetActive(false);

            if (PlayerPrefs.GetInt("Day") > 0)
            {
                buttomContinue.SetActive(true);

                for (int i = 0; i < PlayerPrefs.GetInt("Day"); i++)
                {
                    dayButtom[i].SetActive(true);
                }
            }
        }
    }
    private void Start()
    {
        Display.displays[0].Activate(0, 0, 0);
        Time.timeScale = 1;
        if (playUI != null)
        {
            playUI.SetActive(false);
        }
        if (continueUI != null)
        {
            continueUI.SetActive(false);
        }
        if (cerditUI != null)
        {
            cerditUI.SetActive(false);
        }
        foreach (var item in dayButtom)
        {
            item.SetActive(false);
        }
        CheckDay();
    }
    private void Update()
    {
        InputCode();
    }
}
