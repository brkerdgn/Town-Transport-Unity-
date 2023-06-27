using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarDamage : MonoBehaviour
{
    public HappinessProgress _happinessProgress;
    public Image repairProgress;
    public GameObject speedoMeter;
    public float health;
    public float Damage()
    {
        float currentSpeed = speedoMeter.GetComponent<Speedometer>().speed;
        if (currentSpeed >= 0 && currentSpeed <= 20)
        {
            repairProgress.fillAmount -= 0.02f;

        }
        else if (currentSpeed >= 20 && currentSpeed <= 40)
        {

            repairProgress.fillAmount -= 0.04f;
        }
        else if(currentSpeed >= 40 && currentSpeed <= 60)
        {

            repairProgress.fillAmount -= 0.06f;
        }
        else if(currentSpeed > 60)
        {
            repairProgress.fillAmount -= 0.08f;
        }

        return health;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier") || collision.gameObject.CompareTag("Car"))
        {
            Damage();
        }
    }

}
