using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{

    public Vector3 rotationSpeed = new Vector3(0f, 90f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }



    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
