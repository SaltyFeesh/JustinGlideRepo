using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float cameraOffsetX;
    public float cameraOffsetY;
    public Transform farBackground, middleBackground;
    private Vector2 lastPos;

    private float cameraSize;
    public bool isChangingSize = false;
    public float newSize;
    public float cameraChangeSpeed;

    void Update()
    {
        transform.position = new Vector3(target.position.x+cameraOffsetX, target.position.y+ cameraOffsetY, transform.position.z);

        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        farBackground.position += new Vector3(amountToMove.x * 0.99f, amountToMove.y * 0.99f, 0f);
        middleBackground.position += new Vector3(amountToMove.x * 0.96f, amountToMove.y * 0.96f, 0f);


        lastPos = transform.position;

        if (isChangingSize)
        {
            ChangeCameraSize(newSize);
        }
        
    }

    public void ChangeCameraSize(float newSize)
    {
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, newSize, cameraChangeSpeed);
        if (Mathf.Abs(newSize - Camera.main.orthographicSize) < 1f)
        {
            isChangingSize = false;
        }
    }
}
