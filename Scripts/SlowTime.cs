using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    float cooldown = 1.5f;
    bool CanSlowTime = true;
    public void SlowingTime(float startImpact = 0.7f, float StallTime = 1.0f, float lerpDegree = 0.05f)
    {
        if (CanSlowTime) // what if you want to continuosly slow time, like extend the period like timescale is still at 0.9 
        { 
            StopCoroutine("TimeImpact");
            StartCoroutine(TimeImpact(startImpact, StallTime, lerpDegree));
        }
    }

    IEnumerator TimeImpact(float startImpact, float StallTime, float lerpDegree) // maybe lerp to the start impact as well, hard to test when only the player moves
    {
        StartCoroutine(CoolDownTimer(cooldown));
        Time.timeScale = startImpact;

        yield return new WaitForSecondsRealtime(StallTime);
        while (startImpact <= 1)
        {
            Time.timeScale = startImpact;
            startImpact += lerpDegree;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        Time.timeScale = 1;
    }
    IEnumerator CoolDownTimer(float coolDown)
    {
        CanSlowTime = false;
        yield return new WaitForSecondsRealtime(coolDown);
        CanSlowTime = true;
    }

}
