using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawnPositions : MonoBehaviour
{
    public bool isThereAClient;
    GameObject client;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Client"))
        {
            isThereAClient = true;
            client = other.gameObject;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (isThereAClient)
        {
            if (!client.activeSelf)
            {
                isThereAClient = false;
                client = null;
            }
        }
    }

}
