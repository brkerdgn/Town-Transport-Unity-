using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RespawnController : MonoBehaviour
{
    [SerializeField] Transform raycastPos,repairPos;
    bool isReversed;
    float timer;
    public int repairCost;
    public GameObject respawnButton;

    private void Update()
    {
        if (isReversed)
        {
            ShowRestartButton();
        }
    }

    private void FixedUpdate()
    {
        RespawnCheck();
    }

    private void RespawnCheck()
    {
        RaycastHit hit;

        foreach (Transform transform in raycastPos)
        {
            if (Physics.Raycast(transform.position, -transform.up, out hit, 0.35f))
            {
                if (isReversed) isReversed = false;
                return;
            }
        }
        isReversed = true;
    }


    void ShowRestartButton()
    {
        timer += Time.deltaTime;

        if (timer >= 3f)
        {
            respawnButton.SetActive(true);
            timer = 0f;
        }
    }

    public void RespawnButton()
    {
        this.transform.position = repairPos.transform.position;
        this.transform.rotation = repairPos.transform.rotation;
        if(gameObject.GetComponent<MoneyManager>().moneyCount >= 50)
        {
            gameObject.GetComponent<MoneyManager>().moneyCount -= repairCost;
            respawnButton.SetActive(false);
        }
        else
        {
            respawnButton.SetActive(false);
        }
        
        
    }
}
