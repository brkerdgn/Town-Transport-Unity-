using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _speed = 2f;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z),
            _speed * Time.deltaTime);
        transform.LookAt(_target.parent);
    }
}