using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class CarPool : MonoBehaviour
{
    public static CarPool instance;
    public Queue<GameObject> cars;
    public WaypointManager waypointManager;
    int carCount;
    [SerializeField] GameObject[] carPrefabs;
    [SerializeField] GameObject taxiPrefab;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        carCount = GetComponent<CarSpawner>().maxCars;
        cars = new Queue<GameObject>();
        Generate(carCount);
    }

    private void Generate(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(carPrefabs[Random.Range(0, carPrefabs.Length)], transform);
            go.SetActive(false);
            cars.Enqueue(go);
            go.GetComponent<CarAI>().waypoints = InitiliazeNavigation();
        }
    }

    public GameObject GetCar()
    {
        return cars.Dequeue();
    }

    public void ReturnToPool(GameObject car)
    {
        cars.Enqueue(car);
        car.GetComponent<CarAI>().waypoints = InitiliazeNavigation();
    }

    public GameObject CreateTaxi(GameObject taxi)
    {
        // GameObject taxi = Instantiate(taxiPrefab, transform);

        // taxi.SetActive(false);
        //cars.Enqueue(taxi);
        taxi.GetComponent<NavMeshAgent>().enabled = true;
        taxi.GetComponent<TaxiMark>().enabled = true;
        taxi.GetComponent<CarAI>().enabled = true;
        taxi.GetComponent<CarAI>().waypoints = InitializeTaxiNavigation();
        return taxi;
    }

    private Queue<Vector3> InitiliazeNavigation()
    {
        Queue<Vector3> car = new Queue<Vector3>();
        int randomWay = Random.Range(0, waypointManager.paths.Count);
        foreach (Transform way in waypointManager.enterance)
            car.Enqueue(way.position);
        foreach (Transform way in waypointManager.paths[randomWay])
            car.Enqueue(way.position);
        foreach (Transform way in waypointManager.exit)
            car.Enqueue(way.position);
        return car;
    }

    private Queue<Vector3> InitializeTaxiNavigation()
    {
        Queue<Vector3> car = new Queue<Vector3>();

        foreach (Transform way in waypointManager.exit)
            car.Enqueue(way.position);

        return car;
    }
}