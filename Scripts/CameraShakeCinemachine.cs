using System.Collections;
using System.Collections.Generic;
//using Cinemachine;                      // need to import the package
using UnityEngine;

public class CameraShakeCinemachine : MonoBehaviour
{
    Vector3 OriginPoint, tempoint; 

    [SerializeField][Range(0.001f,1)]
    float shakeStrength;

    [SerializeField][Range(0.01f,2)]
    float time;
   // Cinemachine.CinemachineBasicMultiChannelPerlin Cam;

    public void Awake()
    {
        //Cam = GameObject.FindGameObjectWithTag("HelpCam").GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
       // StopTremble();
    }

    //public IEnumerator Tremble(float duration, float magnitude) 
    //{
    //    float t = 0;

    //    while (t<duration)
    //    {
    //        t += Time.deltaTime;
    //        Cam.m_AmplitudeGain = 0.3f;
    //        Cam.m_FrequencyGain = 10;
    //        yield return new WaitForEndOfFrame();
    //    }
    //    StopTremble();
    //}

    //public void StopTremble()
    //{
    //    Cam.m_AmplitudeGain = Cam.m_FrequencyGain = 0;
    //}
}
