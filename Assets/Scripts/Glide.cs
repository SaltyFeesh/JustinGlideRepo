using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Glide : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("速度调整")]
    public float upwardSlowFactor = 5f;   // 抬头时速度减缓倍率
    public float downwardBoostFactor = 1.5f; // 俯冲时速度增加倍率

    [Header("滑翔控制")]
    public float speed;
    public float rotateSpeed;
    public float speedChange;
    public float maxSpeed;
    public float minSpeed;

    [Header("滑翔限制")]
    private bool isGliding = true;

    [Header("空气阻力")]
    public float dragFactor = 0.99f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
     
        if (!isGliding)
            return;

        // 控制左右转向（平滑）
        float rotateInput = 0f;
        if (Input.GetKey(KeyCode.A)) rotateInput += 1f;
        if (Input.GetKey(KeyCode.D)) rotateInput -= 1f;

        transform.Rotate(0f, 0f, rotateInput * rotateSpeed * Time.deltaTime);

        // 计算当前飞行方向
        Vector2 moveDirection = transform.right * speed;
        rb.velocity = moveDirection;

        // 俯冲加速 / 上升减速（基于朝向）
        float verticalLook = transform.right.y;
        if (verticalLook > 0)
        {
            speed -= speedChange * upwardSlowFactor * Time.deltaTime;
        }
        else if (verticalLook < 0)
        {
            speed += speedChange * downwardBoostFactor * Time.deltaTime;
        }

        // 速度限制
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);

        // 模拟空气阻力
        rb.velocity *= dragFactor;
    }

    void StartGlide()
    {
        isGliding = true;
        rb.gravityScale = 0f;
        speed = 5f; // 初始速度
    }

   
}