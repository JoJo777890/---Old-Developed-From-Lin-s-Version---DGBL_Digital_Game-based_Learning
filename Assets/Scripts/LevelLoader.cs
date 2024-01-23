using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    //public LevelTimer levelTimer;

    public float transitionTime = 1f;
    private int click = 0;
    private int sceneIndex;

    void Awake()
    {
        // Add LevelTimerEnd to "Time's Up" Event
        LevelTimer.onTimeIsUp += LevelTimerEnd;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click++;
            if (click == 2)
            {
                // 原本程式
                LoadNextLevel();

                // 修改程式 (為了方便重新整理 "Level 1")
                //SceneManager.LoadScene(0);
            }
        }
    }

    public void LevelTimerEnd()
    {
        Debug.Log("Stop2!");
        ReloadLevel();
    }

    // Load NextLevel
    public void LoadNextLevel()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (sceneIndex >= 4)
        {
            sceneIndex = 0;
            StartCoroutine(LoadLevel(sceneIndex));
        }
        else
        {
            StartCoroutine(LoadLevel(sceneIndex));
        }
    }

    // Reload Level
    public void ReloadLevel()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
            
        StartCoroutine(ReloadLevel(sceneIndex));
    }

    // Load NextLevel Animation
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    // Reload Level Animation
    IEnumerator ReloadLevel(int levelIndex)
    {
        transition.SetTrigger("Retry End");

        yield return new WaitForSeconds(transitionTime);

        transition.SetTrigger("Retry Start");

        SceneManager.LoadScene(levelIndex);
    }
}
