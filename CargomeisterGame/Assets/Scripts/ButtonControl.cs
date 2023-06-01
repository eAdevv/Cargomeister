using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{

    public GameObject settings;

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsButton()
    {
        settings.SetActive(true);
    }

    public void ResstartButton()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) settings.SetActive(false);
    }


}
