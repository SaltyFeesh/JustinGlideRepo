using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlayer : MonoBehaviour
{

    public Transform pivot;                        // 旋转中心（空物体）
    public float rotationAngle = 20f;              // 绕 Z 轴旋转角度
    public float rotationSpeed = 45f;              // 每秒旋转角度

    private float targetAngle;
    private bool shouldRotate = false;
    private bool hasRotated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasRotated && other.CompareTag("Player"))
        {
            targetAngle = pivot.eulerAngles.z + rotationAngle;
            shouldRotate = true;
        }
    }

    private void Update()
    {
        if (shouldRotate && pivot != null)
        {
            float currentZ = pivot.eulerAngles.z;
            float newZ = Mathf.MoveTowardsAngle(currentZ, targetAngle, rotationSpeed * Time.deltaTime);
            pivot.rotation = Quaternion.Euler(0f, 0f, newZ);

            if (Mathf.Abs(Mathf.DeltaAngle(newZ, targetAngle)) < 0.1f)
            {
                shouldRotate = false;
                hasRotated = true;
            }
        }
    }
}