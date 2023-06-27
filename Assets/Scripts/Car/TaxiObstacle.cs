using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiObstacle : MonoBehaviour
{
    [SerializeField] Transform taxi;
    [SerializeField] UnityEngine.AI.NavMeshObstacle obstacle;
    [SerializeField] Rigidbody rig;

    private void FixedUpdate()
    {
        transform.position = taxi.position;
        transform.rotation = new Quaternion(transform.rotation.x, taxi.rotation.y, transform.rotation.z,transform.rotation.w);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Car") && rig.velocity.magnitude < 1f)
        {
            obstacle.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            obstacle.enabled = false;
        }
    }
}
