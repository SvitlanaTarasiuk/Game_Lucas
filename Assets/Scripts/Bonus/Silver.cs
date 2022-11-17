using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver : MonoBehaviour
{
  
    private void OnBecameInrisable()
    {
        Destroy(gameObject);  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);    
    }
}
