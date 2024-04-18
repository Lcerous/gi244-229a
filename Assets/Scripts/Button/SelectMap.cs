using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour
{
    [SerializeField] private string mapScence;

    public void ChooseMap(string mapName)
    {
        mapScence = mapName;
    }

    public void StartGame()
    {
        if (mapScence == "")
            return;

        Settings.currentScene = mapScence;
        SceneManager.LoadScene(mapScence);
    }
}
