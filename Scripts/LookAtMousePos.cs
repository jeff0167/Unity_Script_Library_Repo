using UnityEngine;

public class LookAtMousePos : MonoBehaviour
{
    Camera cam;
    bool WillLookAtMouse = true;
    void Start()
    {
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        if (!WillLookAtMouse) return;

        var dir = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void LockedRotation(float timeDelay)
    {
        WillLookAtMouse = false;
        Invoke("WillLookAgain",timeDelay);
    }

    void WillLookAgain()
    {
        WillLookAtMouse = true;
    }
}
