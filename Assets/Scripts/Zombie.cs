using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int liveZombie = 5;
        if (collision.transform.tag=="Silver")
      {
        liveZombie --;
        if(liveZombie<=0)
        {
        Destroy(gameObject);
         }
      }
   
    }
}
