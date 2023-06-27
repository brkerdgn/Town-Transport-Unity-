using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentScript : MonoBehaviour
{
    public Vector3 startPos;
    public Quaternion startRot;
    public bool hit;
    public float timerForHit;
    private void Awake()
    {
        startPos = gameObject.transform.position;
        startRot = gameObject.transform.rotation;
    }

   
    void Update()
    {
        SuccessTimer();
    }

    private void SuccessTimer()
    {
        if (hit)
        {
            timerForHit += Time.deltaTime;
            if (timerForHit >= 10)
            {
                gameObject.transform.position = startPos;
                gameObject.transform.rotation = startRot;
                timerForHit = 0;
                hit = false;
            }
        }
     }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Car") || collision.gameObject.CompareTag("Environment"))
        {
            hit = true;
        }
    }
}
