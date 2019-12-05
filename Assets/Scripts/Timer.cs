using System;
using System.Data;
using UnityEngine;

public class Timer: MonoBehaviour
{
    private float countDownTime = 2f;
    private TimerStatus timerStatus = 0;
    private float remainTime = 0;
    public bool Completed => timerStatus == TimerStatus.Stop;

    public Timer(float countDown)
    {
        countDownTime = countDown;
    }

    private void Update()
    {
        if (timerStatus == TimerStatus.Play)
        {
            remainTime -= 1f;
            if (remainTime <= 0)
            {
                timerStatus = TimerStatus.Stop;
            }
        }
    }

    public void Play()
    {
        timerStatus = TimerStatus.Play;
    }

    public void SetTimeCoutDown(float t)
    {
        countDownTime = t;
    }

    public void Restart()
    {
        remainTime = countDownTime;
    }

    private enum TimerStatus
    {
        None,
        Play,
        Stop
    }
}