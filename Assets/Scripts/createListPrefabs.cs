using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createListPrefabs : MonoBehaviour
{
    public GameObject partPrefab;
    public GameObject objectHasList;
    public GameObject objectWithOption;

    [SerializeField]
    private GameObject[] listObjects;

    void Start()
    {
        listObjects = objectHasList.GetComponent<KnotProductions>().productions;
        Vector3 position = gameObject.transform.position;
        position.y -= 45;
        if (listObjects.Length > 0)
        {
            foreach (GameObject objectPart in listObjects)
            {
                GameObject part = Instantiate<GameObject>(partPrefab, position, Quaternion.identity);
                part.transform.SetParent(gameObject.transform, false);
                part.GetComponent<DataproductInList>().parentObject = objectPart;
                part.transform.Find("name").GetComponent<Text>().text = objectPart.GetComponent<Production>().nameRu; // Название
                part.transform.Find("count").GetComponent<Text>().text = objectPart.GetComponent<Production>().countBuy.ToString(); // Количество
                part.transform.Find("exp").GetComponent<Text>().text = objectPart.GetComponent<Production>().needExperience.ToString(); // Нужно науки
                part.transform.Find("profit").GetComponent<Text>().text = objectPart.GetComponent<Production>().profit.ToString(); // Прибыль
                part.transform.Find("price").GetComponent<Text>().text = objectPart.GetComponent<Production>().price.ToString(); // Цена
                part.transform.Find("plus").GetComponent<Button>().onClick.AddListener(delegate { objectWithOption.GetComponent<MainSettings>().PayProduct(objectPart.name); }); // Кнопка покупки
                part.transform.Find("minus").GetComponent<Button>().onClick.AddListener(delegate { objectWithOption.GetComponent<MainSettings>().SellProduct(objectPart.name); }); // Кнопка продажи
                position.y -= 85;
            }
        }
    }

}