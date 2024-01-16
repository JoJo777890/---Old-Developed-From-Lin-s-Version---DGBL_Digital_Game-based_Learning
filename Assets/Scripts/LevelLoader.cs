using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    private int click = 0;
    private int sceneIndex;

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

    public void LoadNextLevel()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if(sceneIndex >= 4)
        {
            sceneIndex = 0;
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            StartCoroutine(LoadLevel(sceneIndex));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
