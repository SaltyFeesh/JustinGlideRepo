using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStoneDrop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.GetChild(0).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
