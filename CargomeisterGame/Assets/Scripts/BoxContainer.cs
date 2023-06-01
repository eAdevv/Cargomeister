using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class BoxContainer : MonoBehaviour
{
    private float score;
    private float timeCount;
    [SerializeField]private float time;
    public TextMeshProUGUI scoreText, timeText;
    public GameObject gameOverPanel;
    public GameObject nicePanel;

    private void Start()
    {
        timeCount = time;
    }

    private void Update()
    {
        timeCount -= Time.deltaTime;

        timeText.text = "Time : " + (int)timeCount;

        if (timeCount <= 0)
        {
            gameOverPanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(1);
            
        }


        if (score >= 30f)
        { 
            nicePanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(1);


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Box"))
        {
            Destroy(collision.gameObject);
            score += 1f;
            scoreText.text = " " + (int)score;
        }

    }


}
