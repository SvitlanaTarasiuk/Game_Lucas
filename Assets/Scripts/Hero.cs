using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hero: MonoBehaviour
{
    [SerializeField]private float speed = 3f;
    [SerializeField]private float jumpForce = 15f;
    [SerializeField] private TextMeshProUGUI textCoint;
    [SerializeField] private TextMeshProUGUI textDiamond;
    [SerializeField] private GameUI gameUI;
    public int coins = 0;
    public int life = 5;
    public int key = 0;
    public int diamond = 0;
   
    //public Color[]color;
    //private int indexColor = 0;
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    //private MeshRenderer mr;

    public int Key
    {
        get => key;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        //mr = GetComponent<MeshRenderer>();
    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    void Update()
    {
        if (Input.GetButton("Horizontal"))
         Run(); 
        if (isGrounded && Input.GetButtonDown("Jump"))
         Jump(); 
    }
    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position+dir,speed*Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }
    private void Jump()
    {
        rb.AddForce(transform.up*jumpForce,ForceMode2D.Impulse);
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position+Vector3.down,0.3f);

        isGrounded = collider.Length > 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Coins")
        {
            coins += 100;
            textCoint.text = coins.ToString();
            Destroy(collision.gameObject);
        }


        if (collision.tag == "Diamond")
        {
            coins += 1000;
            textCoint.text = coins.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Heart")
        {
            life +=1;
            Destroy(collision.gameObject);
            gameUI.AddHeart();
          
        }
        if (collision.tag =="Diamond")
        {
            diamond += 5;
            Destroy(collision.gameObject);
            textDiamond.text = diamond.ToString();
            Damage();
        }
        if (collision.tag == "Enemy")
        {   
            life -=1;
            Destroy(collision.gameObject);
            gameUI.RemuveHeart();
            Damage();
        }
        if (collision.tag == "SpicesEnemy")
        {
            life -= 1;           
            //mr.material.color = color[indexColor];
            //indexColor = ++indexColor % color.Length;
            gameUI.RemuveHeart();
            Damage();
            //sprite.material.color = new Color(0.66f, 0.2f, 0.2f);
           
        }
        if (collision.tag == "Key")
        {
            key +=1;

            Destroy(collision.gameObject);
        }
    }
    private void Damage()
    {   
        if (life==0)
        {
            Time.timeScale = 0;
            gameUI.GameOver();
        }
    }

}
