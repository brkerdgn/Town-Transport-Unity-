using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    private List<GameObject> _bodies = new List<GameObject>();
    private int _currentBody = 0;

    private void Start()
    {
        foreach (Transform go in this.transform)
        {
            _bodies.Add(go.gameObject);
        }
    }

    public void ChangeBody(int index)
    {
        _bodies[_currentBody].SetActive(false);
        _currentBody = index;
        _bodies[index].SetActive(true);
    }
}