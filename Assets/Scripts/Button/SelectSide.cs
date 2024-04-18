using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSide : MonoBehaviour
{
    [SerializeField] private string mainMenuScence;
    [SerializeField] private string chooseMapScence;

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScence);
    }

    public void GoToChooseMap()
    {
        SceneManager.LoadScene(chooseMapScence);
    }

    public void ChooseSide(int i)
    {
        Settings.SelectSide(i);
        GoToChooseMap();
    }
}
