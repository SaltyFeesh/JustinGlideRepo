using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Glide : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("�ٶȵ���")]
    public float upwardSlowFactor = 5f;   // ̧ͷʱ�ٶȼ�������
    public float downwardBoostFactor = 1.5f; // ����ʱ�ٶ����ӱ���

    [Header("�������")]
    public float speed;
    public float rotateSpeed;
    public float speedChange;
    public float maxSpeed;
    public float minSpeed;

    [Header("��������")]
    private bool isGliding = true;

    [Header("��������")]
    public float dragFactor = 0.99f;
    
    public bool isInAir = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isInAir)
        {
            return;
        }
     
        if (!isGliding)
            return;

        // ��������ת��ƽ����
        float rotateInput = 0f;
        if (Input.GetKey(KeyCode.A)) rotateInput += 1f;
        if (Input.GetKey(KeyCode.D)) rotateInput -= 1f;

        transform.Rotate(0f, 0f, rotateInput * rotateSpeed * Time.deltaTime);

        // ���㵱ǰ���з���
        Vector2 moveDirection = transform.right * speed;
        rb.velocity = moveDirection;

        // ������� / �������٣����ڳ���
        float verticalLook = transform.right.y;
        //print(verticalLook);
        if (verticalLook > 0 && verticalLook < 0.3f)
        {
            speed -= speedChange * upwardSlowFactor * Time.deltaTime * 0.3f;
        }
        else if (verticalLook >= 0.3f && verticalLook < 0.6f)
        {
            speed -= speedChange * downwardBoostFactor * Time.deltaTime * 0.6f;
        }
        else if (verticalLook < 0)
        {
            speed += speedChange * downwardBoostFactor * Time.deltaTime;
        }

        
        // �ٶ�����
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);

        if (speed == 0)
        {
            // game over, reload scene
        }

        // ģ���������
        rb.velocity *= dragFactor;
    }

    void StartGlide()
    {
        isGliding = true;
        rb.gravityScale = 0f;
        speed = 5f; // ��ʼ�ٶ�
    }

   
}