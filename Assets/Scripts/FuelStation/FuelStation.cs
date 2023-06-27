using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FuelStation : MonoBehaviour
{
    public Image image;
    public GameObject money;


    public void Buy()
    {
        if (money.GetComponent<MoneyManager>().moneyCount >= 0 && image.fillAmount != 1)
        {
            image.fillAmount += Time.deltaTime / 2;
        }
        
    }
}
