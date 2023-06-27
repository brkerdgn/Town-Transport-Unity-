using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiMark : MonoBehaviour
{
    [SerializeField] Transform arrow;

    Camera cam;

    private void OnEnable()
    {
        arrow.gameObject.SetActive(true);
    }
    
    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        arrow.LookAt(cam.transform);
    }
}
