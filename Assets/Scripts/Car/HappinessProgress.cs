using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HappinessProgress : MonoBehaviour
{
    public Image progressBar;
    public GameObject happy, smile, normal, bad, angry;
    void Start()
    {
        progressBar.fillAmount = 0.5f;
    }

   
    void Update()
    {
        if (progressBar.fillAmount >= 0.8f)
        {
            happy.SetActive(true);
            smile.SetActive(false);
            normal.SetActive(false);
            bad.SetActive(false);
            angry.SetActive(false);
        }
        else if (progressBar.fillAmount >=0.6f)
        {

            happy.SetActive(false);
            smile.SetActive(true);
            normal.SetActive(false);
            bad.SetActive(false);
            angry.SetActive(false);
        }
        else if (progressBar.fillAmount >= 0.4f)
        {
            happy.SetActive(false);
            smile.SetActive(false);
            normal.SetActive(true);
            bad.SetActive(false);
            angry.SetActive(false);
        }
        else if (progressBar.fillAmount >= 0.2f)
        {
            happy.SetActive(false);
            smile.SetActive(false);
            normal.SetActive(false);
            bad.SetActive(true);
            angry.SetActive(false);
        }
        else if (progressBar.fillAmount >= 0.0f)
        {
            happy.SetActive(false);
            smile.SetActive(false);
            normal.SetActive(false);
            bad.SetActive(false);
            angry.SetActive(true);
        }
    }
}
