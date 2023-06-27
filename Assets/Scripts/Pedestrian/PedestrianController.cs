using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianController : MonoBehaviour
{
    //bool isWalking;
    NavMeshAgent agent;

    Vector3 walkDestination;

    public enum whichWay
    {
        forward,
        backward
    }

    public whichWay pedestrianWay;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        agent.SetDestination(walkDestination);
    }

    public void Walk(Transform destination)
    {
        walkDestination = destination.position;
        //isWalking = true;
    }
}
