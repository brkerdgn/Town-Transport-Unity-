using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoRepair : MonoBehaviour
{
    public Image image;
    public GameObject money;

    public void Buy(int moneyAmount)
    {

        if (money.GetComponent<MoneyManager>().moneyCount >= 0 && image.fillAmount != 1)
        {
            image.fillAmount += Time.deltaTime / 2;
        }
    }
}
