using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happiness : MonoBehaviour
{
    public DestinationTimer destination;
    public HappinessProgress _happinessProgress;

    private void OnCollisionEnter(Collision collision)
    {
        if (!destination._isEmptyNow)
        {
            if (collision.gameObject.CompareTag("Barrier") || collision.gameObject.CompareTag("Car"))
            {
                _happinessProgress.progressBar.fillAmount -= 0.1f;
            }
        }
    }
}
