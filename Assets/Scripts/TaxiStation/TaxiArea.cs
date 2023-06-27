using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaxiArea : MonoBehaviour
{
    public GameObject canvas, taxiArea, taxiAreaSec;
    public float cost;
    public TextMeshProUGUI textmesh;

    public void Buy(int moneyAmount)
    {
        cost -= moneyAmount * Time.deltaTime * 4;

        if (cost <= 0)
        {
            canvas.SetActive(false);
            taxiArea.SetActive(false);
            taxiAreaSec.SetActive(true);

        }
    }
    private void Update()
    {
        textmesh.text = Mathf.CeilToInt(cost).ToString();
    }
}
