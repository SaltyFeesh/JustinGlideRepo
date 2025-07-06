using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float rotateSpeed;
    public float speedChange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 根据玩家朝向设置速度方向
        Vector2 moveDirection = transform.right * speed;
        rb.velocity = moveDirection;

        if (transform.right.y > 0)
        {
            speed -= speedChange * 5f * Time.deltaTime;
        }
        else if (transform.right.y < 0)
        {
            speed += speedChange * Time.deltaTime;
        }

        speed = Mathf.Clamp(speed, -3f, 5f);


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, -rotateSpeed * Time.deltaTime));
        }
    }
}