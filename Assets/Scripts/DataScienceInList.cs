using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataScienceInList : MonoBehaviour
{
    public GameObject parentObject;

    private string status;
    private bool open;


    void Update()
    {
        status = parentObject.GetComponent<Science>().status;

        if(status == "W")
        {
            gameObject.transform.Find("BuyBtn").gameObject.SetActive(true);
        }
        if (status == "Y")
        {
            gameObject.transform.Find("BuyBtn").gameObject.SetActive(false);
            gameObject.transform.Find("BuyText").gameObject.SetActive(true);
        }
        if (status == "N")
        {
            gameObject.transform.Find("BuyBtn").gameObject.SetActive(false);
        }
    }
}
