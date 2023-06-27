using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaxiStationAi : MonoBehaviour
{
    public bool[] taxiList;
    public GameObject[] taxiFeaturesList;
    public GameObject canvasOKTaxi,buttonOK1,buttonOk2,buttonOK3,buttonOk4, ýnsufficientButton;
    int purchasableTaxiCount;
    public int purchasedTaxi;
    int time = 30;
    public GameObject[] taxis;
    [SerializeField] CarSpawner spawner;
    [SerializeField] MoneyManager money;
    public Text taxiCountOkTaxi;
    TaxiFeatures taxiFeatures;
    int taxiFeaturesCount,totalEarning = 0;
    

    private void Start()
    {
        purchasableTaxiCount = taxis.Length;
        taxiList = new bool[purchasableTaxiCount];
        taxiFeatures = taxiFeaturesList[taxiFeaturesCount].GetComponent<TaxiFeatures>();
    }

    private void Update()
    {
        taxiCountOkTaxi.text = purchasedTaxi.ToString();

    }

    public void PurchaseTaxiOne()
    {
       
        if (true && purchasedTaxi < purchasableTaxiCount)
        {
            taxiFeaturesCount = 0;
            if (money.moneyCount >= taxiFeaturesList[taxiFeaturesCount].GetComponent<TaxiFeatures>().cost)
            {
                money.moneyCount -= taxiFeaturesList[taxiFeaturesCount].GetComponent<TaxiFeatures>().cost;
                purchasedTaxi++;
                totalEarning += taxiFeatures.earningHour;
                taxiList[purchasedTaxi - 1] = true;
                CarPool.instance.CreateTaxi(taxis[purchasedTaxi - 1]);
                spawner.maxCars++;
                buttonOK1.SetActive(true);
                taxiFeaturesList[taxiFeaturesCount].GetComponent<TaxiFeatures>().Success();
                canvasOKTaxi.SetActive(true);
            }else
            {
                ýnsufficientButton.SetActive(true);
            }
        }
    }

    public void PurchaseTaxiTwo()
    {
       
        if (true && purchasedTaxi < purchasableTaxiCount)
        {
            taxiFeaturesCount = 1;
            if (money.moneyCount >= taxiFeaturesList[taxiFeaturesCount].GetComponent<TaxiFeatures>().cost)
            {
                money.moneyCount -= taxiFeaturesList[taxiFeaturesCount].GetComponent<TaxiFeatures>().cost;
                purchasedTaxi++;
                totalEarning += taxiFeatures.earningHour;
                taxiList[purchasedTaxi - 1] = true;
                CarPool.instance.CreateTaxi(taxis[purchasedTaxi - 1]);
                spawner.maxCars++;
                buttonOk2.SetActive(true);
                taxiFeaturesList[taxiFeaturesCount].GetComponent<TaxiFeatures>().Success(); 
                canvasOKTaxi.SetActive(true);
            }
            else
            {
                ýnsufficientButton.SetActive(true);
            }
        }
    }

    public void PurchaseTaxiThree()
    {
        
        if (true && purchasedTaxi < purchasableTaxiCount)
        {
            taxiFeaturesCount = 2;
            if (money.moneyCount >= taxiFeaturesList[taxiFeaturesCount].GetComponent<TaxiFeatures>().cost)
            {
                money.moneyCount -= taxiFeaturesList[taxiFeaturesCount].GetComponent<TaxiFeatures>().cost;
                purchasedTaxi++;
                totalEarning += taxiFeatures.earningHour;
                taxiList[purchasedTaxi - 1] = true;
                CarPool.instance.CreateTaxi(taxis[purchasedTaxi - 1]);
                spawner.maxCars++;
                buttonOK3.SetActive(true);
                taxiFeaturesList[taxiFeaturesCount].GetComponent<TaxiFeatures>().Success();
                canvasOKTaxi.SetActive(true);
            }
            else
            {
                ýnsufficientButton.SetActive(true);
            }
        }
    }
    public void PurchaseTaxiFour()
    {
        
        if (true && purchasedTaxi < purchasableTaxiCount)
        {
            taxiFeaturesCount = 3;
            if (money.moneyCount >= taxiFeaturesList[taxiFeaturesCount].GetComponent<TaxiFeatures>().cost)
            {
                money.moneyCount -= taxiFeaturesList[taxiFeaturesCount].GetComponent<TaxiFeatures>().cost;
                purchasedTaxi++;
                totalEarning += taxiFeatures.earningHour;
                taxiList[purchasedTaxi - 1] = true;
                CarPool.instance.CreateTaxi(taxis[purchasedTaxi - 1]);
                spawner.maxCars++;
                buttonOk4.SetActive(true);
                taxiFeaturesList[taxiFeaturesCount].GetComponent<TaxiFeatures>().Success();
                canvasOKTaxi.SetActive(true);
            }
            else
            {
                ýnsufficientButton.SetActive(true);
            }
        }
    }

    public void TaxiEarn()
    {
        if (purchasedTaxi >= 0)
        {
            StartCoroutine(AIEarnMoney());
        }
    }

    IEnumerator AIEarnMoney()
    {
        while (true)
        {
            money.moneyCount += totalEarning;
            yield return new WaitForSecondsRealtime(time);
        }
    }

    public void TamamButtonTaxi()
    {
        canvasOKTaxi.SetActive(false);
    }

    public void ýnsufficientButtonExit()
    {
        ýnsufficientButton.SetActive(false);
    }
}