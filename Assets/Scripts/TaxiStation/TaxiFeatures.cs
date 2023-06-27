using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaxiFeatures : MonoBehaviour
{
    public GameObject hireEmployeer, costT, earnHourT;
    public Text costText, earningHourText;
    public int cost,earningHour;

    private void Update()
    {
        costText.text = cost.ToString();   
        earningHourText.text = earningHour.ToString();  
    }

    public void Success()
    {
        hireEmployeer.SetActive(false);
        costT.SetActive(false);
        earnHourT.SetActive(false);
    }
}
