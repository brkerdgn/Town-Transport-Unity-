using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObstackle : MonoBehaviour
{
    public GameObject taxi;

    private void Awake()
    {
        taxi = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        if (taxi.GetComponent<Rigidbody>().velocity.magnitude > 1)
        {
           taxi.GetComponent<UnityEngine.AI.NavMeshObstacle>().enabled = false;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && taxi.GetComponent<Rigidbody>().velocity.magnitude < 1)
        {
            taxi.GetComponent<UnityEngine.AI.NavMeshObstacle>().enabled = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && taxi.GetComponent<Rigidbody>().velocity.magnitude < 1)
        {
            taxi.GetComponent<UnityEngine.AI.NavMeshObstacle>().enabled = false;

        }
    }
}
