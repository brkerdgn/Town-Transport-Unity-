using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaxiStationUI : MonoBehaviour
{
    public GameObject backgroundUI, taxiUI,joystick,taxi,canvasOKMoto,buttonDriver,buttonUpgrade,buttonMax, canvasSettings,canvasGameSet,canvasSoundMute,canvasSound,buyingTaxi;
    public Text speedText,speedTextOKMoto;
    public float engineSpeed,turnSpeed;
    public float speed = 90,upgradeCost = 50;
    public bool isEnable,sound=true;
    public AudioSource audio;
    [SerializeField] MoneyManager money;
    private void Start()
    {
        turnSpeed = taxi.GetComponent<DriveCar>().movingTurnsSpeed;  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TaxiStation"))
        {
            joystick.SetActive(false);
            backgroundUI.SetActive(false);
            taxiUI.SetActive(true);
            isEnable = true;
        }      
    }
   public void ButtonPlay()
    {      
        joystick.SetActive(true);
        backgroundUI.SetActive(true);
        taxiUI.SetActive(false);
        isEnable = false;
    }

    private void Update()
    {
        speedText.text = speed.ToString();
    }
    public void SettingsButton()
    {
        canvasSettings.SetActive(true);

    }

    public void ContinueButton()
    {
        canvasSettings.SetActive(false);
       
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("oyun kapandý");
    }

    public void GameSettingButton()
    {
        canvasGameSet.SetActive(true);
    }

    public void GameSettingsOK()
    {
        canvasGameSet.SetActive(false);
    }

    public void GameSettingsSound()
    {
       
        if (sound == true)
        {
            audio.mute = true;
            sound = false;
            canvasSound.SetActive(false);
            canvasSoundMute.SetActive(true);
        }
        else
        {
            audio.mute = false;
            sound = true;
            canvasSound.SetActive(true);
            canvasSoundMute.SetActive(false);
        }
    }

    public void BuyTaxi()
    {
        buyingTaxi.SetActive(true);
    }

    public void BuyingTaxiExit()
    {
        buyingTaxi.SetActive(false);
        
    }
}
