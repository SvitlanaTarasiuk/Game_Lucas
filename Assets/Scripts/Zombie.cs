using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private int liveZombie = 5;
    private SpriteRenderer sprRend;
    private Material matBlinc;
    private Material matDefault;
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
        matBlinc = Resources.Load("EnemyBlinc", typeof(Material)) as Material;
        matDefault = sprRend.material;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.transform.tag=="Silver")
        {
            liveZombie --;
            sprRend.material = matBlinc; 

           if(liveZombie<=0)
           {
            Destroy(gameObject);
           }
        }
   
    }
}
