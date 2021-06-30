using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class KnotProductions : MonoBehaviour
{
    public GameObject[] productions;
    public GameObject PersonalData;

    public void BuyProduction(int quantity, string nameBuy)
    {
        if (productions.Length > 0)
        {
            foreach (GameObject production in productions)
            { // Проход всех производств
                string nameProd = production.GetComponent<Production>().name;
                if (nameBuy == nameProd) // Поиск того производства которое указано в вызове метода, поиск по названию
                {
                    bool dun = PersonalData.GetComponent<PersonalData>().BuyProduction(production, quantity);

                    if (dun)
                    {
                        production.GetComponent<Production>().Buy(quantity);
                    }
                }
            }
        }
    }

    public void SellProduction(int quantity, string nameBuy)
    {
        if (productions.Length > 0)
        {
            foreach (GameObject production in productions)
            {
                string nameProd = production.GetComponent<Production>().name;
                if (nameBuy == nameProd) // Поиск того производства которое указано в вызове метода, поиск по названию
                {
                    bool dan = PersonalData.GetComponent<PersonalData>().SellProduction(production, quantity);
                    
                    if (dan) // Вместо true | false
                    {
                        production.GetComponent<Production>().Sell(quantity);
                    }
                }
            }
        }
    }
}
