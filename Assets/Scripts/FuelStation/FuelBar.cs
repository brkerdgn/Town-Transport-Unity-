using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Image image;
    float timer = 0;
    void Update()
    {
          if (image.fillAmount<=0.50)
        {
            Debug.Log(timer);
            image.color = Color.red;
            if (image.color == Color.red)
            {
                timer += Time.deltaTime;
                if(timer >= 2.0f)
                {
                    image.color = Color.black;
                    if (image.color == Color.black)
                    {
                        if(timer >= 4.0f)
                        {
                            image.color = Color.red;
                            timer = 0;
                        }
                    }
                }
            }
        }else
        {
            image.color = Color.yellow;
        }
    }
}
