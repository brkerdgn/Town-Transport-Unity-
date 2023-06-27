using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelUpgradeArea : MonoBehaviour
{
    public GameObject joystick, levelUpgrade,canvasUI;
    public Animator anim;
    public float cost;


    public TextMeshProUGUI textmesh;
    private void Update()
    {
        textmesh.text = Mathf.CeilToInt(cost).ToString();
    }
    public void Buy(int moneyAmount)
    {
        cost -= moneyAmount * Time.deltaTime * 12;

        if (cost <= 0)
        {
            levelUpgrade.SetActive(false);
            this.enabled = false;
            canvasUI.SetActive(true);
            anim.SetBool("isUpgraded", true);
        }    
    }
 
}