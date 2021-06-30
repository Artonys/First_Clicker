using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataproductInList : MonoBehaviour
{
    public GameObject parentObject;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Find("count").GetComponent<Text>().text = parentObject.GetComponent<Production>().countBuy.ToString();
        gameObject.transform.Find("profit").GetComponent<Text>().text = parentObject.GetComponent<Production>().profit.ToString();
    }
}
