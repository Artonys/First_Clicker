using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : MonoBehaviour
{
    public int price;
    public int sell;
    public string nameEn;
    public string nameRu;
    public string code;
    public int id;
    public float profit;
    public float needExperience;
    public string nameProduction;

    private int realPrice;
    private float realSell;
    private float realProfit;
    private string saveCode;
    public int countBuy = 0;
    private float fullProfit;

    private void Start()
    {
        saveCode = code + id;
        if (PlayerPrefs.HasKey(saveCode))
        {
            countBuy = PlayerPrefs.GetInt(saveCode);
        }
    }

    public void Buy(int quantity)
    {
        countBuy += quantity;
        fullProfit = profit * quantity;
        PlayerPrefs.SetInt(saveCode, countBuy);
    }

    public float[] CalcBuy(int quantity)
    {
        realPrice = price * quantity;
        realProfit = profit * quantity;
        float[] arResult = { realPrice, realProfit, needExperience };
        return arResult;
    }

    public float[] CalcSell(int quantity)
    {
        float canSell = 0;

        if (countBuy >= quantity)
        {
            realSell = sell * quantity;
            realProfit = profit * quantity;
            canSell = 1;
        }

        float[] arResult = { realSell, realProfit, canSell };
        return arResult;
    }

    public void Sell(int quantity)
    {
        countBuy -= quantity;
        fullProfit = profit * quantity;
        PlayerPrefs.SetInt(saveCode, countBuy);
    }
}
