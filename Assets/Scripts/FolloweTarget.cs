using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolloweTarget : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset = new Vector3(14, 0, -10);
    // Start is called before the first frame update
    //void Start()
    //{
    //    offset = transform.position - playerTransform.position;
    //    Debug.Log(offset);
    //}

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}
