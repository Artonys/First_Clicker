using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portmone : MonoBehaviour
{
    public float money;
    public float profit;
    public float science;
    public int countProduction;
    public int maxCountProduction;

    private float miliSecond;
    private float second;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetFloat("money");
        }
        if (PlayerPrefs.HasKey("profit"))
        {
            profit = PlayerPrefs.GetFloat("profit");
        }
        if (PlayerPrefs.HasKey("science"))
        {
            science = PlayerPrefs.GetFloat("science");
        }
        if (PlayerPrefs.HasKey("countProduction"))
        {
            countProduction = PlayerPrefs.GetInt("countProduction");
        }
    }

    private void FixedUpdate()
    {
        miliSecond += 0.02f;
        if (miliSecond >= 1) // Одна сек
        {
            second++;
            miliSecond = 0;
            money += profit;
            PlayerPrefs.SetInt("countProduction", countProduction);
            PlayerPrefs.SetFloat("money", money);
            PlayerPrefs.SetFloat("profit", profit);
            PlayerPrefs.SetFloat("science", science);
            PlayerPrefs.Save();
        }
    }
}
