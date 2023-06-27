using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public List<GameObject> cars = new List<GameObject>();

    public int maxCars;

    public bool canCreateCarNow;

    [Range(1f, 5f)]
    public float minSpawnTime;

    [Range(5f, 10f)]
    public float maxSpawnTime;

    private void Start()
    {
        StartCoroutine(SpawnCar());
    }

    // public IEnumerator SpawnTaxi()
    // {
    //     while (true)
    //     {
    //         if (canCreateCarNow)
    //         {
    //             GameObject taxi = CarPool.instance.CreateTaxi();
    //             cars.Add(taxi);
    //
    //             taxi.transform.position = this.transform.position;
    //             taxi.transform.rotation = this.transform.rotation;
    //             taxi.SetActive(true);
    //             break;
    //         }
    //
    //         else
    //         {
    //             yield return new WaitForSeconds(1f);
    //         }
    //     }
    //
    //     yield return null;
    // }


    IEnumerator SpawnCar()
    {
        while (true)
        {
            if (cars.Count < maxCars)
            {
                canCreateCarNow = true;

                yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

                canCreateCarNow = false;

                GameObject car = CarPool.instance.GetCar();
                cars.Add(car);

                car.transform.position = this.transform.position;
                car.transform.rotation = this.transform.rotation;

                car.SetActive(true);
            }
            yield return null;
        }
    }
}
