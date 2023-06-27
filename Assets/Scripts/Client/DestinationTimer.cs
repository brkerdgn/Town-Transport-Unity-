using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
using UnityEngine.UI;

public class DestinationTimer : MonoBehaviour
{
    private ClientController _client;
    public HappinessProgress _happinessProgress;
    [SerializeField] private ClientSpawner clientSpawner;
    public GameObject timerIm,timerOn,failed,success;
    [SerializeField] private float timeLimitMultiplier;
    public TextMeshProUGUI minText,secText;
    private float _timer;
    private float _timeLimit;
    public bool _isEmptyNow = true, failedBool,successBool;
    public float Timer => _timer;
    public float timerFailed;
    private void Update()
    {
        int min = Mathf.FloorToInt(Timer / 60f);
        int sec = Mathf.FloorToInt(Timer % 60f);
        
        minText.SetText(min.ToString());
        secText.SetText(sec.ToString());
        ReachClient();
        FailedTimer();
        SuccessTimer();
        if (_client != null)
        {
            TimeController();
        }
    }

    private void ReachClient()
    {
        if (_client == null)
        {
            if (clientSpawner.takenClient == null)
            {
                return;
            }

            _client = clientSpawner.takenClient.GetComponent<ClientController>();
            _timeLimit = Vector3.Distance(_client.firstPos, _client.destination) * timeLimitMultiplier;
            timerIm.SetActive(true);
            failed.SetActive(false);
            timerOn.SetActive(true);
            success.SetActive(false);
            _timer = _timeLimit;
            _isEmptyNow = false;
        }

        if (clientSpawner.takenClient == null && _client != null)
        {
            _client = null;
        }
    }

 

    private void TimeController()
    {
        if (_client != null && !_isEmptyNow)
        {
            _timer -= Time.deltaTime;

            if (_timer < 0)
            {
                _timer = _timeLimit;
                failedBool = true;
                _happinessProgress.progressBar.fillAmount -= 0.2f;
                clientSpawner.ReturnClient();
                _isEmptyNow = true;
            }

            if (clientSpawner.HasTaxiArrivedOnTime && _timer > 0)
            {
                _happinessProgress.progressBar.fillAmount += 0.2f;
                successBool = true;
                _isEmptyNow = true;
            }
        }

        else
        {
    
        }
    }
    private void FailedTimer()
    {
        if (failedBool)
        {
            timerOn.SetActive(false);
            failed.SetActive(true);

            if (timerOn.activeSelf == false)
            {
                timerFailed += Time.deltaTime;
                if (timerFailed >= 2)
                    {
                        timerIm.SetActive(false);
                        timerFailed = 0;
                        failedBool = false;
                    }
            }
        }
    }
    private void SuccessTimer()
    {
        if (successBool)
        {
            timerOn.SetActive(false);
            success.SetActive(true);

            if (timerOn.activeSelf == false)
            {
                timerFailed += Time.deltaTime;
                if (timerFailed >= 2) 
                {
                    timerIm.SetActive(false);
                    timerFailed = 0;
                    successBool = false;
                }                   
            }
        }
    }
}