using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyFlowScript : MonoBehaviour
{

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, GameObject.FindGameObjectWithTag("Finish").transform.position, 5f * Time.deltaTime);
    }
}
