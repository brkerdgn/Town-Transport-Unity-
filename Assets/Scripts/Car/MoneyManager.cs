using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class MoneyManager : MonoBehaviour
{
    public Image fuelImage,repairImage;
    public float moneyCount = 0;
    public TextMeshProUGUI text;

    private void OnEnable()
    {
        
        TriggerManager.OnFuelStation += Fuel;
        TriggerManager.OnRepairStation += autoRepair;
        TriggerManager.OnTaxiBuy += TaxiBuy;
        TriggerManager.OnLevelUpgrade += Level;
    }
    private void OnDisable()
    {
        TriggerManager.OnFuelStation -= Fuel;
        TriggerManager.OnRepairStation -= autoRepair;
        TriggerManager.OnTaxiBuy -= TaxiBuy;
        TriggerManager.OnLevelUpgrade -= Level;
    }

    private void Start()
    {
        moneyCount = PlayerPrefs.GetFloat(nameof(moneyCount), moneyCount);
    }

    private void Update()
    {
        PlayerPrefs.SetFloat(nameof(moneyCount), moneyCount);
        text.SetText(moneyCount.ToString("0"));
    }
    IEnumerator FuelMoneyDown()
    {
        if (moneyCount >= 1 && fuelImage.fillAmount != 1)
        {
            moneyCount -= 1;
            yield return new WaitForSeconds(5.0f);
        }
    }
    IEnumerator RepairMoneyDown()
    {
        if (moneyCount >= 1 && repairImage.fillAmount != 1)
        {
            moneyCount -= 1;
            yield return new WaitForSeconds(5.0f);
        }
    }
    void Fuel()
    {
        if (TriggerManager.OnFuel != null)
        {
            if (moneyCount >= 1 && fuelImage.fillAmount != 1)
            {
                TriggerManager.OnFuel.Buy();
                StartCoroutine(FuelMoneyDown());
            }
        }
    }

    void autoRepair()
    {
        if (TriggerManager.autoRepair != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.autoRepair.Buy(1);
                StartCoroutine(RepairMoneyDown());
            }
        }
    }

    void TaxiBuy()
    {
        if (TriggerManager.taxiBuy != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.taxiBuy.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 4;
            }
        }
    }
    void Level()
    {
        if (TriggerManager.levelUpgrade != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.levelUpgrade.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 12;
            }
        }
    }


    [MenuItem("Player Pref/Clear")]

    static void Init()
    {
        PlayerPrefs.DeleteAll();
    }
}
