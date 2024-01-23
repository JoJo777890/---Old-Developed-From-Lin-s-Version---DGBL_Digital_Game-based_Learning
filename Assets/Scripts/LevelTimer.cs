using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    private float timer;
    public float timerLength = 3f;

    public TextMeshProUGUI levelTimerText;

    public static event Action onTimeIsUp;

    void Start()
    {
        timer = timerLength;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        levelTimerText.text = string.Format("Timer: {0:0}", timer);

        if (timer < 0)
        {
            timer = 10;
            Debug.Log("Stop!");
            onTimeIsUp?.Invoke();
        }
    }
}
