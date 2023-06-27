using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientDestination : MonoBehaviour
{
    ClientSpawner spawner;

    bool isCustomerArrived;

    public string stopNo;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Client Spawner").GetComponent<ClientSpawner>();
        stopNo = $"{transform.parent.name + transform.name}";
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && ClientSpawner.haveTaxiClient)
        {
            if (other.GetComponentInParent<Rigidbody>().velocity.magnitude < 0.5f && !isCustomerArrived && spawner.arrivingPoint.Equals(stopNo))
            {
                isCustomerArrived = true;
                transform.GetComponent<Target>().enabled = false;

                spawner.takenClient.transform.position = transform.position;
                spawner.takenClient.SetActive(true);
                spawner.takenClient.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
                spawner.CloseTaximeter();
                spawner.HasTaxiArrivedOnTime = true;
                //spawner.takenClient.GetComponent<ClientController>().CreateMoneyOnScreen();

                ClientMoneyPool.clientMoneyPool.ShowMoney(spawner.takenClient.GetComponent<ClientController>().money, Camera.main.WorldToScreenPoint(spawner.takenClient.transform.position));



                StartCoroutine(DisableClient());
            }
        }
    }


    IEnumerator DisableClient()
    {
        yield return new WaitForSeconds(3f);
        spawner.ReturnClient();
        isCustomerArrived = false;
    }
}
