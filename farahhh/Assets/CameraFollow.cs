using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Follow Settings")]
    public Transform Target;
    public float Cameraspeed;
    public float minX, maxX;
    public float minY, maxY;

    [Header("Camera Zoom Settings")]
    private Camera Cam;
    public float TargetZoom = 3f; // The value of Zoom I want by manipulating the Camera Size
    private float ScrollData; // Float collected upon Mouse Scrolling
    public float ZoomSpeed = 3f; // Speed of zooming process in or out

    void Start()
    {
        Cam = GetComponent<Camera>();
        TargetZoom = Cam.orthographicSize; // The game will begin with TargetZoom being assigned the default given
    }

    void Update()
    {
        // 1. قراءة حركة بكرة الماوس
        ScrollData = Input.GetAxis("Mouse ScrollWheel");

        // 2. تحديث قيمة TargetZoom بناءً على حركة الماوس
        TargetZoom = TargetZoom - ScrollData;

        // 3. وضع حدود للزووم عشان ما يبقاش كبير أو صغير بزيادة
        TargetZoom = Mathf.Clamp(TargetZoom, 3f, 6f);

        // 4. جعل انتقال حجم الكاميرا سلساً وناعماً باستخدام Lerp
        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, TargetZoom, Time.deltaTime * ZoomSpeed);
    }

    void FixedUpdate()
    {
        if (Target != null)
        {
            Vector2 newCamPosition = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * Cameraspeed);
            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);
            transform.position = new Vector3(ClampX, ClampY, -10f);
        }
    }
}