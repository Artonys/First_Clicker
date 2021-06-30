using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnotSciences : MonoBehaviour
{
    public GameObject[] sciences;
    public GameObject PersonalData;

    public void BuyScience(string nameBuy)
    {
        if (sciences.Length > 0)
        {
            foreach (GameObject science in sciences)
            { // Проход всех наук
                string nameProd = science.GetComponent<Science>().name;
                if (nameBuy == nameProd) // Поиск того производства которое указано в вызове метода, поиск по названию
                {
                    float price = science.GetComponent<Science>().price; // Получение полной стоимости
                    float scienceData = science.GetComponent<Science>().science; // Получение полной стоимости
                    float[] realPrice = {price, 0, scienceData};
                    bool dun = PersonalData.GetComponent<PersonalData>().BuyEverything(realPrice); // Покупка, получение true | false

                    if (dun)
                    {
                        science.GetComponent<Science>().Buy();
                    }
                }
            }
        }
    }

}
