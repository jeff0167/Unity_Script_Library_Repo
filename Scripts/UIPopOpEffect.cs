using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopOpEffect : MonoBehaviour
{
    [SerializeField]
    Camera cam; // in all display sizes
    [SerializeField]
    Transform target;

    [SerializeField]
    Vector2 offset;

    [SerializeField]
    TMPro.TextMeshProUGUI text;

    void OnEnable() // screen space overlay makes the canvas scale to be 4.8! can´t change it in this render mode
    {
        text = GameObject.FindGameObjectWithTag("Finish").GetComponent<TMPro.TextMeshProUGUI>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        text.text = transform.localScale.x.ToString();
        Debug.Log(transform.localScale.x.ToString());
        StartCoroutine("NextFrame"); // sadly this is needed to have a consistent scale, also the offset is off because it is being set on the UI which is scaled by chosen resolution, a scale that multiplies with the offset is needed
    }

    public void PopUp(Transform t, Vector2 v)// should have animation like a pop-up effect, possibly increasing in size, and fade
    {
        target = t;
        offset = v;
        Vector2 screenPos = cam.WorldToScreenPoint(t.position);
        transform.position = screenPos + offset;
    }

    IEnumerator NextFrame()
    {
        yield return new WaitForEndOfFrame();
        transform.localScale = new Vector3(1, 1, 1);
    }
}
