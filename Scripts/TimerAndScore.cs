using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAndScore : MonoBehaviour
{
    float timeValue;
    int scoreValue;

    [SerializeField]
    TMPro.TextMeshProUGUI timeText, scoreText;
    public void StartTimer()
    {
        ResetTime();
        InvokeRepeating("OneSecInterval",1,1);
    }
    public void ResetScore()
    {
        scoreValue = 0;
        scoreText.text = scoreValue.ToString();
    }

    public void ResetTime()
    {
        timeValue = 0;
        timeText.text = timeValue.ToString();
    }

    public IEnumerator UpdateEveryFrame()
    {
        while (true)
        {
            timeValue += Time.deltaTime;
            timeText.text = timeValue.ToString("f2");
            yield return new WaitForEndOfFrame();
        }
    }

    public void StopTime()
    {
        StopAllCoroutines();
    }

    public void OneSecInterval()
    {
        timeValue += 1;
        timeText.text = timeValue.ToString("f2");
    }

    public void GiveScore(int val)
    {
        scoreValue += val;
        scoreText.text = scoreValue.ToString();
    }

    public int GetScore()
    {
        return scoreValue;
    }
    public float GetTime()
    {
        return timeValue;
    }
}
