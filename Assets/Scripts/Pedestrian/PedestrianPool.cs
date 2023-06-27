using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianPool : MonoBehaviour
{
    public static PedestrianPool instance;
    
    public GameObject[] prefabs;

    public Queue<GameObject> queue = new Queue<GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public void GeneratePedestrian(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform);
            queue.Enqueue(go);
            go.SetActive(false);
        }
    }


    public GameObject GetPedestrian()
    {
        return queue.Dequeue();
    }


}
