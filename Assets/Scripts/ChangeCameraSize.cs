using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraSize : MonoBehaviour
{
    public float size;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraController>().isChangingSize = true;
            Camera.main.GetComponent<CameraController>().newSize = size;
        }
    }
}
