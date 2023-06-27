using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    [SerializeField] ClientPool pool;

    [Header("Spawn Values")] [SerializeField]
    int maxClientNumber;

    int currentActiveClientCount;

    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;

    [Header("Positions")] public List<Transform> locations = new List<Transform>();
    public List<Transform> destinations = new List<Transform>();

    int locationIndex;
    int spawnIndex;

    public string arrivingPoint;

    [Space] public List<GameObject> activeClients = new List<GameObject>();

    public GameObject takenClient;
    public static bool haveTaxiClient;

    [Space] [SerializeField] Taximeter taximeter;

    private int destinationIndex;
    private int destinationPoint;

    public bool HasTaxiArrivedOnTime { get; set; }

    private void Start()
    {
        pool.GenerateClient(pool.prefabs.Length);
        StartCoroutine(SpawnClient());
    }

    private void Update()
    {
        GetClientToTaxi();
    }

    private void GetClientToTaxi()
    {
        if (!haveTaxiClient)
        {
            for (int i = 0; i < activeClients.Count; i++)
            {
                if (activeClients[i].GetComponent<ClientController>().hasTaken)
                {
                    haveTaxiClient = true;

                    //pool.ReturnClient(activeClients[i]);


                    takenClient = activeClients[i];
                    ClientController taken = takenClient.GetComponent<ClientController>();
                    taken.isClientAvaliable = false;
                    taken.destination = DecideDestination();
                    HasTaxiArrivedOnTime = false;

                    int money = CalculateMoney(takenClient);
                    taken.money = money;
                    taximeter.UpdateTaximeter(money);

                    activeClients.Remove(activeClients[i]);
                    currentActiveClientCount--;

                    takenClient.SetActive(false);

                    break;
                }
            }
        }
    }

    Vector3 DecideSpawnLocation()
    {
        do
        {
            locationIndex = Random.Range(0, locations.Count);
            spawnIndex = Random.Range(0, locations[locationIndex].childCount);
        } while (locations[locationIndex].GetChild(spawnIndex).GetComponent<ClientSpawnPositions>().isThereAClient);

        return locations[locationIndex].GetChild(spawnIndex).position;
    }


    Vector3 DecideDestination()
    {
        destinationIndex = Random.Range(0, destinations.Count);

        destinationPoint = Random.Range(0, destinations[destinationIndex].childCount);

        destinations[destinationIndex].GetChild(destinationPoint).GetComponent<Target>().enabled = true;

        arrivingPoint = $"{destinationIndex.ToString() + destinationPoint.ToString()}";

        return destinations[destinationIndex].GetChild(destinationPoint).position;
    }

    public void ReturnClient()
    {
        destinations[destinationIndex].GetChild(destinationPoint).GetComponent<Target>().enabled = false;
        CloseTaximeter();
        pool.ReturnClient(takenClient);
        takenClient = null;
        haveTaxiClient = false;
    }

    IEnumerator SpawnClient()
    {
        while (true)
        {
            if (currentActiveClientCount < maxClientNumber)
            {
                float time = Random.Range(minSpawnTime, maxSpawnTime);
                yield return new WaitForSeconds(time);

                currentActiveClientCount++;
                GameObject client = pool.GetClient();

                Vector3 spawnPos = DecideSpawnLocation();

                client.transform.position = spawnPos;
                client.transform.rotation = locations[locationIndex].rotation;
                client.transform.parent = this.transform;
                client.SetActive(true);

                activeClients.Add(client);
            }

            yield return null;
        }
    }


    public int CalculateMoney(GameObject client)
    {
        Vector3 firstPos = client.GetComponent<ClientController>().firstPos;
        Vector3 destination = client.GetComponent<ClientController>().destination;

        float money = Mathf.Abs(destination.magnitude - firstPos.magnitude);

        return (int)money;
    }

    public void CloseTaximeter()
    {
        taximeter.gameObject.SetActive(false);
    }
}