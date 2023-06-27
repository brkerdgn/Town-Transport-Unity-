using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientPool : MonoBehaviour
{
    public GameObject[] prefabs;

    public Queue<GameObject> queue = new Queue<GameObject>();

    public void GenerateClient(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform);
            queue.Enqueue(go);
            go.SetActive(false);
        }
    }

    public GameObject GetClient()
    {
        return queue.Dequeue();
    }

    public void ReturnClient(GameObject client)
    {
        queue.Enqueue(client);
        client.SetActive(false);
        client.transform.parent = this.transform;
    }

}
