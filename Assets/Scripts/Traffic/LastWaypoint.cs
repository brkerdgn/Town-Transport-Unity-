using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastWaypoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            other.gameObject.SetActive(false);
            CarPool.instance.ReturnToPool(other.gameObject);
            GameObject.FindGameObjectWithTag("Car Spawner").GetComponent<CarSpawner>().cars.Remove(other.gameObject);
        }
    }
}
