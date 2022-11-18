using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    private int liveZombie = 5;
    private SpriteRenderer sprRend;
    
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.transform.tag=="Silver")
        {
            liveZombie --;
            sprRend.color = colorDamage;

           if(liveZombie<=0)
           {
            Destroy(gameObject);
           }
            else
           {
               Invoke("ResetMaterial",0.5f);

           }
        }
   
    }
    void ResetMaterial()
    {
        //sprRend.material = matDefault;
        sprRend.color = Color.white;
    }
}
