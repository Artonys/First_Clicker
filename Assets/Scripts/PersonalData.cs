using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersonalData : MonoBehaviour
{
    public GameObject objectMoneyText;
    public GameObject PricePassive;
    public GameObject Portmone;
    public GameObject ScienceData;
    public GameObject CountPr;
    public GameObject MaxCountPr;

    private float money;
    private float profit;
    public GameObject TimeMoney;
    public GameObject CanvasMoney;

    private float miliSecond;
    private float miliSecondToExit;
    private float second;
    private string moneyText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("LastTime"))
        {
            long savedTime = long.Parse(PlayerPrefs.GetString("LastTime"));
            System.TimeSpan timeSpan = System.DateTime.UtcNow - new System.DateTime(savedTime);
            TimeSpan ts = timeSpan;
            float FinalTime = ts.Hours * 3600 + ts.Minutes * 60 + ts.Seconds;
            if (FinalTime > 1800)
            {
                FinalTime = 1800;
            }
            if (FinalTime > 0)
            {
                float addMoney = FinalTime * (Portmone.GetComponent<Portmone>().profit / 2);
                Portmone.GetComponent<Portmone>().money += addMoney;
                CanvasMoney.SetActive(true);
                TimeMoney.GetComponent<Text>().text = addMoney.ToString();
                SetExitTime();
            }
        }
        GenerateText();
    }

    public float GetScience()
    {
        float science = Portmone.GetComponent<Portmone>().science;
        return science;
    }
    public bool BuyEverything(float[] localProfit)
    {
        float science = 0;
        float price = localProfit[0];
        float addProfit = localProfit[1];
        if (localProfit[2] > 0)
        {
            science = localProfit[2];
        }
        bool result = false;
        money = Portmone.GetComponent<Portmone>().money;

        if (money >= price)
        {
            Portmone.GetComponent<Portmone>().money -= price;
            money -= price;
            Portmone.GetComponent<Portmone>().profit += addProfit;
            profit += addProfit;
            if (science > 0)
            {
                Portmone.GetComponent<Portmone>().science += science;
            }

            result = true;
        }

        GenerateText();
        return result;
    }

    public void SellEverything(float[] localProfit)
    {
        float price = localProfit[0];
        float addProfit = localProfit[1];

        Portmone.GetComponent<Portmone>().money += price;
        money += price;
        Portmone.GetComponent<Portmone>().profit -= addProfit;
        profit -= addProfit;

        GenerateText();
    }

    public bool SellProduction(GameObject currentObj, int quantity)
    {
        int countBuy = currentObj.GetComponent<Production>().countBuy;
        if (countBuy >= quantity)
        {
            float realSell = currentObj.GetComponent<Production>().sell * quantity;
            float realProfit = currentObj.GetComponent<Production>().profit * quantity;

            Portmone.GetComponent<Portmone>().money += realSell;
            Portmone.GetComponent<Portmone>().profit -= realProfit;
            Portmone.GetComponent<Portmone>().countProduction -= quantity;

            GenerateText();

            return true;
        }
        return false;
    }

    public bool BuyProduction(GameObject currentObj, int quantity)
    {
        float price = currentObj.GetComponent<Production>().price;
        float addProfit = currentObj.GetComponent<Production>().profit;
        bool CanBuy = CanBuyProduction(currentObj, quantity);

        if (CanBuy)
        {
            Portmone.GetComponent<Portmone>().money -= (float)System.Math.Round(price * quantity, 0);
            Portmone.GetComponent<Portmone>().profit += (float)System.Math.Round(addProfit * quantity, 1);
            Portmone.GetComponent<Portmone>().countProduction += quantity;
            GenerateText();
            return true;
        }
        else
        {
            GenerateText();
            return false;
        }
    }

    public bool CanBuyProduction(GameObject currentObj, int quantity)
    {
        int MyCount = Portmone.GetComponent<Portmone>().countProduction;
        int MaxCount = Portmone.GetComponent<Portmone>().maxCountProduction;
        if (MyCount >= MaxCount) return false; // Проверка на лимит предприятий
        
        float priceL = currentObj.GetComponent<Production>().price * quantity;
        float moneyL = Portmone.GetComponent<Portmone>().money;
        if (priceL > moneyL) return false; // Хватает ли денег
        
        float needExperience = currentObj.GetComponent<Production>().needExperience;
        float science = Portmone.GetComponent<Portmone>().science;
        if (needExperience > science) return false; // Проверка на доступность по науке
        
        return true;
    }

    private void GenerateText()
    {
        money = (float)System.Math.Round(Portmone.GetComponent<Portmone>().money, 0);
        moneyText = textAfterCount(money);
        objectMoneyText.GetComponent<Text>().text = moneyText.ToString();
        PricePassive.GetComponent<Text>().text = System.Math.Round(Portmone.GetComponent<Portmone>().profit, 1).ToString();
        ScienceData.GetComponent<Text>().text = Portmone.GetComponent<Portmone>().science.ToString();
        CountPr.GetComponent<Text>().text = Portmone.GetComponent<Portmone>().countProduction.ToString();
        MaxCountPr.GetComponent<Text>().text = "(" + Portmone.GetComponent<Portmone>().maxCountProduction.ToString() + ")";
    }

    private string textAfterCount(float num)
    {
        string text = "";
        float money = num;

        if (num > 999 && num < 99999)
        {
            text = "K";
            money = (float)System.Math.Round(num / 1000, 0);
        }
        else if (num > 99999)
        {
            money = (float)System.Math.Round(num / 100000, 0);
            text = "M";
        }
        return money + " " + text;
    }
    private void SetExitTime()
    {
        long currenttime = System.DateTime.UtcNow.Ticks;
        PlayerPrefs.SetString("LastTime", currenttime.ToString());
    }

    private void FixedUpdate()
    {
        miliSecond += 0.02f;
        miliSecondToExit += 0.02f;
        if (miliSecond >= 0.1)
        {
            money = Portmone.GetComponent<Portmone>().money;
            miliSecond = 0;
            GenerateText();
        }
        if (miliSecondToExit >= 1) // Одна сек
        {
            second++;
            miliSecondToExit = 0;
        }
        if (second == 1)
        {
            SetExitTime();
            second = 0;
        }
    }
}
