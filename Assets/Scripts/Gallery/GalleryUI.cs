using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GalleryUI : MonoBehaviour
{
    public GameObject[] Cars = new GameObject[4];
    public GameObject mainUI, galleryUI, gallery,buyButton,useButton, ýnsufficientButton;
    public Camera mainCamera, galleryCamera;
    public AudioSource sound;
    public int value = 0;
    public TextMeshProUGUI cost, fuel, speed, name,moneyText;
    public MoneyManager money;
    public bool isBuyed;
    public DriveCar driveCar;

    public int _carIndex = 0;
    [SerializeField] private BodyController body;


    private void Start()
    {
        ChangeTag();
    }

    private void ChangeTag()
    {
        CarFeatures carFeatures = Cars[_carIndex].GetComponent<CarFeatures>();
        name.SetText(carFeatures.name);
        cost.SetText(carFeatures.cost);
        fuel.SetText(carFeatures.fuel);
        speed.SetText(carFeatures.speed);
    }

    public void EnterGallery()
    {
        mainUI.SetActive(false);
        mainCamera.enabled = false;
        galleryUI.SetActive(true);
        galleryCamera.enabled = true;
        gallery.SetActive(true);
        sound.GetComponent<TaxiStationUI>().audio.mute = true;
    }

    public void ExitButton()
    {
        mainUI.SetActive(true);
        mainCamera.enabled = true;
        galleryUI.SetActive(false);
        galleryCamera.enabled = false;
        gallery.SetActive(false);
        sound.GetComponent<TaxiStationUI>().audio.mute = false;
    }

    private void Update()
    {
        moneyText.SetText(money.moneyCount.ToString());
    }
    public void RightButton()
    {
        Cars[_carIndex].SetActive(false);

        _carIndex = _carIndex == Cars.Length - 1 ? 0 : _carIndex + 1;

        Cars[_carIndex].SetActive(true);

        ChangeTag();

        if (Cars[_carIndex].GetComponent<CarFeatures>().isBought)
        {
            buyButton.SetActive(false);
            useButton.SetActive(true); 
        }
        else
        {
            buyButton.SetActive(true);
            useButton.SetActive(false);
        }
        
    }

    public void LeftButton()
    {
        Cars[_carIndex].SetActive(false);

        _carIndex = _carIndex == 0 ? Cars.Length - 1 : _carIndex - 1;

        Cars[_carIndex].SetActive(true);

        ChangeTag();

        if (Cars[_carIndex].GetComponent<CarFeatures>().isBought)
        {
            buyButton.SetActive(false);
            useButton.SetActive(true);
        }
        else
        {
            buyButton.SetActive(true);
            useButton.SetActive(false);
        }

    }


    public void BuyButton()
    {
        if(money.moneyCount >= (float.Parse)(cost.text))
        {
            money.moneyCount -= (float.Parse)(cost.text);
            buyButton.SetActive(false);
            useButton.SetActive(true);
            CarFeatures carFeatures = Cars[_carIndex].GetComponent<CarFeatures>();
            carFeatures.isBought = true;
        }
        else
        {
            ýnsufficientButton.SetActive(true);
        } 
    }

    public void UseButton()
    {
        body.ChangeBody(_carIndex);
        mainUI.SetActive(true);
        mainCamera.enabled = true;
        galleryUI.SetActive(false);
        galleryCamera.enabled = false;
        gallery.SetActive(false);
        sound.GetComponent<TaxiStationUI>().audio.mute = false;
        CarFeatures carFeatures = Cars[_carIndex].GetComponent<CarFeatures>();
        driveCar.normalSpeed = (float.Parse)(carFeatures.speed) * 2;
        Debug.Log(driveCar.normalSpeed);
    }

    public void ýnsufficientButtonExit()
    {
        ýnsufficientButton.SetActive(false);
    }
}