using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSize : MonoBehaviour
{
    [SerializeField]
    AnimationCurve myCurve;

    [SerializeField]
    bool myLoop = true;

    [SerializeField]
    enum lerp { Resize, PingPong, PingPongWithCurve }

    [SerializeField]
    lerp lerping;

    [SerializeField]
    float LerpSpeed;

    void Start()
    {
        switch (lerping)
        {
            case lerp.Resize:
                Resize();
                break;
            case lerp.PingPong:
                PingPong();
                break;
            case lerp.PingPongWithCurve:
                PingPongWithCurve();
                break;
        }
    }
    public void Resize()
    {
        StartCoroutine(Resize(this.gameObject, 1.5f, 0.0001f)); // not really lerping but okey
    }
    public void PingPong()
    {
        StartCoroutine(PingPong(this.gameObject, LerpSpeed));
    }
    public void PingPongWithCurve()
    {
        StartCoroutine(PingPongWithCurve(this.gameObject, myCurve, LerpSpeed));
    }

    IEnumerator Resize(GameObject objectToScale, float sizeProcent, float speed) // scales based on size
    {
        float index = 1;
        sizeProcent += objectToScale.transform.localScale.x;

        while (objectToScale.transform.localScale.x <= sizeProcent)
        {
            index += speed;
            objectToScale.transform.localScale *= index;
            yield return null;
        }
    }

    IEnumerator PingPong(GameObject objectToScale, float speed)
    {
        while (myLoop)
        {
            float scaleValue = Mathf.PingPong(Time.time * speed, 1);
            Vector3 scale = new Vector3(scaleValue, scaleValue, scaleValue);

            objectToScale.transform.localScale = scale;
            yield return null;
        }
    }

    IEnumerator PingPongWithCurve(GameObject objectToScale, AnimationCurve anim, float speed)
    {
        float t = 0;
        while (myLoop)
        {
            t += Time.deltaTime * speed;

            float scaleValueAnim = anim.Evaluate(t);
            Vector3 scale = new Vector3(scaleValueAnim, scaleValueAnim, scaleValueAnim);

            objectToScale.transform.localScale = scale;

            yield return null;
        }
    }
}
