using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Science : MonoBehaviour
{
    public string code;
    public int id;
    public string nameEn;
    public string nameRu;
    public float price;
    public float science;
    public string status;
    public GameObject thisOpenAfter;

    private string saveCode;

    private void Start()
    {
        saveCode = code + id;
        if (PlayerPrefs.HasKey(saveCode))
        {
            status = PlayerPrefs.GetString(saveCode);
        }
    }

    public void toWait()
    {
        status = "W";
        PlayerPrefs.SetString(saveCode, "W");
    }
    public void Buy()
    {
        if (status != "Y")
        {
            if (thisOpenAfter != null)
            {
                thisOpenAfter.GetComponent<Science>().toWait();
            }
            status = "Y";
            PlayerPrefs.SetString(saveCode, "Y");
        }
    }
}