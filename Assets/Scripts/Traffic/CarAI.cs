using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    NavMeshAgent agent;
    
    [HideInInspector]
    public Vector3 nextWaypoint;

    public Queue<Vector3> waypoints;

    public AudioSource audio;

    public float rayLen = 5;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        audio = GetComponent<AudioSource>();
    }


    private void Start()
    {
        nextWaypoint = waypoints.Dequeue();
    }


    private void Update()
    {
        agent.SetDestination(nextWaypoint);
    }


    private void FixedUpdate()
    {
        RaycastHit ray;


        foreach (Transform transform in transform.GetChild(0))
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward * rayLen, Color.red);

            if (Physics.Raycast(transform.position, transform.forward, out ray, rayLen))
            {
                if (ray.collider.CompareTag("Car") || ray.collider.CompareTag("Player"))
                {
                    agent.velocity = Vector3.zero;
                    audio.Play();
                }
            }
        }

       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waypoint"))
        {
            if (waypoints.Count != 0)
            {
                nextWaypoint = waypoints.Dequeue();
            }
        }
    }


}
