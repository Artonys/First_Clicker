using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Production
{
    private void Start()
    {
        price = 100;
        sell = 50;
        profit = 0.5f;
        needExperience = 0;
    }
}
