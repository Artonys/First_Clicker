using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MainSettings : MonoBehaviour
{
    public GameObject objectMoneyText;
    public GameObject objectFactoriesCount;
    public GameObject objectFactoriesCountText;
    public GameObject KnotProductions;
    public GameObject KnotScience;
    public GameObject PersonalData;

    private float miliSecond;
    private float second;
    private GameObject[] listPanes;

    public void Start()
    {
        listPanes = GameObject.FindGameObjectsWithTag("panels");
    }

    public void PayProduct(string nameBuy)
    {
        int quantity = 1;
        KnotProductions.GetComponent<KnotProductions>().BuyProduction(quantity, nameBuy);
    }
    public void SellProduct(string nameBuy)
    {
        int quantity = 1;
        KnotProductions.GetComponent<KnotProductions>().SellProduction(quantity, nameBuy);
    }

    public void BuyScience(string nameBuy)
    {
        KnotScience.GetComponent<KnotSciences>().BuyScience(nameBuy);
    }

    public void MainClick()
    {
        float[] clickTouch = {1, 0};
        PersonalData.GetComponent<PersonalData>().SellEverything(clickTouch);
        foreach (GameObject panel in listPanes)
        {
            panel.SetActive(false);
        }
    }

    public void OpenOptions()
    {

        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    void OnApplicationPause(bool pauseStatus)
    {
        PlayerPrefs.Save();
    }

}
