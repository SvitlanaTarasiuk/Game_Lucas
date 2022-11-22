using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    private int liveZombie = 10;
    private SpriteRenderer sprRend;
    private float dirX;
    private float speed =3f; 
    private bool moveingRigth=true;
    private Object explosion;
    void Start()
    {   
        sprRend = GetComponent<SpriteRenderer>();
        explosion = Resources.Load("Explosion");        
    }
    void Update()
    {
        if(transform.position.x>8.5f)
        {
            moveingRigth= false;    
        }
            else if(transform.position.x<-3f)
        {
            moveingRigth= true;
        }
            if(moveingRigth)
        {
            transform.position= new Vector2(transform.position.x + speed * Time.deltaTime,transform.position.y); 
        }
            else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
         }
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
                GameObject explosionRef = (GameObject)Instantiate(explosion);
                explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
           }
            else
           {
               Invoke("ResetMaterial",0.5f);
           }
        }
   
    }
    void ResetMaterial()
    {
        sprRend.color = Color.white;
    }
}
