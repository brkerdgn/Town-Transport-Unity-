using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Taximeter : MonoBehaviour
{

    [SerializeField] ClientSpawner spawner;

    [SerializeField] TextMeshProUGUI tmp;

    public void UpdateTaximeter(int text)
    {
        tmp.SetText(text + ".00");
        gameObject.SetActive(true);
    }
}
