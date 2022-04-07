using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GuiManager : MonoBehaviour
{
    public Button btnPause;
    public Button btnResume;
    public static bool GameIsPaused = false;
    float currentTime;
    public Text currentTimeText;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        btnPause.onClick.AddListener(btnPauseClick);
        btnResume.onClick.AddListener(btnResumeClick);
    }

    // Update is called once per frame
    void Update()
    {
        //Bouton pause
        if (GameIsPaused)
        {
            Time.timeScale = 0f;
        }
        if (!GameIsPaused)
        {
            Time.timeScale = 1f;
        }
        //Chronomètre
        currentTime = currentTime + Time.deltaTime;
        TimeSpan time =  TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
    }

    void btnPauseClick()
    {
        //Pause le jeu
        GameIsPaused = true ;
    }

    void btnResumeClick()
    {
        //Reprends le jeu
        GameIsPaused = false ;
    }
}
