using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnFuelArea();
    public static event OnFuelArea OnFuelStation;
    public static FuelStation OnFuel;

    public delegate void OnAutoRepair();
    public static event OnAutoRepair OnRepairStation;
    public static AutoRepair autoRepair;

    public delegate void OnTaxiArea();
    public static event OnTaxiArea OnTaxiBuy;
    public static TaxiArea taxiBuy;

    public delegate void OnLevelArea();
    public static event OnLevelArea OnLevelUpgrade;
    public static LevelUpgradeArea levelUpgrade;


    public GameObject gas, repair;
    public Animator fuelAreaAnim,repairAnim,taxiAreaAnim1,levelArea;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fuel"))
        {
            gas.SetActive(false);
            fuelAreaAnim.SetBool("FuelAreaAnim", true);
            OnFuelStation();
            OnFuel = other.gameObject.GetComponent<FuelStation>();
        }
        if (other.gameObject.CompareTag("AutoRepair"))
        {
            repair.SetActive(false);
            repairAnim.SetBool("RepairAnim", true);
            OnRepairStation();
            autoRepair = other.gameObject.GetComponent<AutoRepair>();
        }
        if (other.gameObject.CompareTag("TaxiArea"))
        {
            taxiAreaAnim1.SetBool("TaxiAreaAnim1", true);
            OnTaxiBuy();
            taxiBuy = other.gameObject.GetComponent<TaxiArea>();
        }
        if (other.gameObject.CompareTag("Level"))
        {
            levelArea.SetBool("LevelUpAnim", true);
            OnLevelUpgrade();
            levelUpgrade = other.gameObject.GetComponent<LevelUpgradeArea>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fuel"))
        {
            gas.SetActive(true);
            fuelAreaAnim.SetBool("FuelAreaAnim", false);
            OnFuel = null;
        }
        if (other.gameObject.CompareTag("AutoRepair"))
        {
            repair.SetActive(true);
            repairAnim.SetBool("RepairAnim", false);
            autoRepair = null;
        }
        if (other.gameObject.CompareTag("TaxiArea"))
        {
            taxiAreaAnim1.SetBool("TaxiAreaAnim1", false);
            taxiBuy = null;
        }
        if (other.gameObject.CompareTag("Level"))
        {
            levelArea.SetBool("LevelUpAnim",false);
            levelUpgrade = null;

        }
    }
}
