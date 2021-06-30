using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class optionsScript : MonoBehaviour
{
    public void CloseGame()
    {
        Application.Quit();
    }

    public void ClearGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void BackToGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
