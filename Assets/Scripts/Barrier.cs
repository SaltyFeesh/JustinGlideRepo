using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;

public class Barrier : MonoBehaviour
{

    public static event Action onPlayerDied;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("·¢ÉúÅö×²ÁË");
        
        if(collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);
            Die();
        
        }     
    }

    private void Die()
    {
        onPlayerDied?.Invoke(); 
    }
}
