using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SciencePartList : MonoBehaviour
{
    public GameObject partPrefab;
    public GameObject objectHasList;
    public GameObject objectWithOption;

    [SerializeField]
    private GameObject[] listObjects;

    void Start()
    {
        listObjects = objectHasList.GetComponent<KnotSciences>().sciences;
        Vector3 position = gameObject.transform.position;
        position.y -= 54;
        if (listObjects.Length > 0)
        {
            foreach (GameObject objectPart in listObjects)
            {
                GameObject part = Instantiate<GameObject>(partPrefab, position, Quaternion.identity);
                part.transform.SetParent(gameObject.transform, false);
                part.GetComponent<DataScienceInList>().parentObject = objectPart;
                part.transform.Find("name").GetComponent<Text>().text = objectPart.GetComponent<Science>().nameRu; // Название
                part.transform.Find("science").GetComponent<Text>().text = objectPart.GetComponent<Science>().science.ToString(); // Прибыль
                part.transform.Find("price").GetComponent<Text>().text = objectPart.GetComponent<Science>().price.ToString(); // Цена
                part.transform.Find("BuyBtn").GetComponent<Button>().onClick.AddListener(delegate { objectWithOption.GetComponent<MainSettings>().BuyScience(objectPart.name); }); // Кнопка покупки
                position.y -= 105;
            }
        }
    }
}
