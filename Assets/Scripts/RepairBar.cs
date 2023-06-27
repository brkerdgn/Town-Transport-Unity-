using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RepairBar : MonoBehaviour
{
    public Image image;
    float timerRepair = 0;
    void Update()
    {
        if (image.fillAmount <= 0.50)
        {
            image.color = Color.red;
            if (image.color == Color.red)
            {
                timerRepair += Time.deltaTime;
                if (timerRepair >= 2.0f)
                {
                    image.color = Color.black;
                    if (image.color == Color.black)
                    {
                        if (timerRepair >= 4.0f)
                        {
                            image.color = Color.red;
                            timerRepair = 0;
                        }
                    }
                }
            }
        }
        else
        {
            image.color = Color.green;
        }
    }
}
