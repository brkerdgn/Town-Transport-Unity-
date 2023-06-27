using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingUI : MonoBehaviour
{
    public GameObject background;
    public void StartButton()
    {
      background.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
