using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianWalkController : MonoBehaviour
{
    [SerializeField] int count;
    int active;

    [SerializeField] Transform next;
    [SerializeField] Transform prev;

    public float minSpawnTime;

    public float maxSpawnTime;

    public List<GameObject> pedestrians;

    public enum whichWay
    {
        forward,
        backward
    }

    public whichWay way;

    private void Start()
    {
        PedestrianPool.instance.GeneratePedestrian(count);
        StartCoroutine(CallPedestrian());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pedestrian"))
        {
            switch (other.GetComponent<PedestrianController>().pedestrianWay)
            {
                case PedestrianController.whichWay.forward:
                    other.GetComponent<PedestrianController>().Walk(next);
                    break;

                case PedestrianController.whichWay.backward:
                    other.GetComponent<PedestrianController>().Walk(prev);
                    break;
            }
        }
    }

    IEnumerator CallPedestrian()
    {
        while (true)
        {
            if (active < count)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

                //int size = Random.Range(1, 3);

                //for (int i = 0; i < size; i++)
                //{
                GameObject go = PedestrianPool.instance.GetPedestrian();
                pedestrians.Add(go);

                go.transform.position = transform.position;
                go.transform.rotation = transform.rotation;
                go.transform.parent = transform;

                switch (way)
                {
                    case whichWay.forward:
                        go.GetComponent<PedestrianController>().Walk(next);
                        go.GetComponent<PedestrianController>().pedestrianWay = PedestrianController.whichWay.forward;
                        break;

                    case whichWay.backward:
                        go.GetComponent<PedestrianController>().Walk(prev);
                        go.GetComponent<PedestrianController>().pedestrianWay = PedestrianController.whichWay.backward;
                        break;

                }


                go.SetActive(true);
                active++;
                //}
            }
            yield return null;
        }
    }
}
