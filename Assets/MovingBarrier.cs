using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBarrier : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // 到达目标点后切换目标
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }
}
