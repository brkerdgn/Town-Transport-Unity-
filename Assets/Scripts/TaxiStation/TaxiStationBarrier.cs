using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiStationBarrier : MonoBehaviour
{
    public Animator animLeft,animRight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TaxiStationBarrier"))
        {
            animLeft.SetBool("isOpening", true);
            animRight.SetBool("isOpening", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TaxiStationBarrier"))
        {
            animLeft.SetBool("isOpening", false);
            animRight.SetBool("isOpening", false);  
        }
    }
}
