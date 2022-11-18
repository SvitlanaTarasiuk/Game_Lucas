using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private TextMeshProUGUI textCoint;
    [SerializeField] private TextMeshProUGUI textDiamond;
    [SerializeField] private TextMeshProUGUI textSilver;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private Rigidbody2D silver;
    [SerializeField] private Color colorDamage;
    private bool isRigth = true;

    public int coins = 0;
    public int life = 5;
    public int key = 0;
    public int diamond = 0;
    public int silvercount = 0;

    private bool isGrounded = false;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    //private Animator anim;

    public int Key
    {
        get => key;
    }

    /*void Start()
    {
        coins = GlobalControl.Instantiate.coins;
        life = GlobalControl.Instantiate.life;
        diamond = GlobalControl.Instantiate.diamond;
    }*/
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        //anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    void Update()
    {
        if (Time.timeScale >= 1)
        {
            if (Input.GetButton("Horizontal"))
            { Run(); }
            if (isGrounded && Input.GetButtonDown("Jump"))
            { Jump(); }
            Attack();
        }
    }
    private void Run()
    {
        float move = Input.GetAxis("Horizontal");
        Vector3 dir = transform.right * move;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        Flip(move);
    }
    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position + Vector3.down, 0.3f);
        isGrounded = collider.Length > 1;
    }
    private void Flip(float move)
    {
        if (move < 0 && isRigth)
        {
            isRigth = false;
            sprite.flipX = true;
        }
        if (move > 0 && !isRigth)
        {
            isRigth = true;
            sprite.flipX = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coins")
        {
            coins += 100;
            textCoint.text = coins.ToString();
            Destroy(collision.gameObject);
            //SavePlayer();
        }
        /*if (collision.tag == "Silver")
        {
            silvercount += 1;
            textCoint.text = coins.ToString();
            Destroy(collision.gameObject);
        }*/
        if (collision.tag == "Heart")
        {
            life += 1;
            //SavePlayer();
            Destroy(collision.gameObject);
            gameUI.AddHeart();
        }
        if (collision.tag == "Diamond")
        {
            diamond += 5;
            Destroy(collision.gameObject);
            //SavePlayer();
            textDiamond.text = diamond.ToString();
            Damage();
        }
        if (collision.tag == "Enemy")
        {
            life -= 1;
            //SavePlayer();
            Destroy(collision.gameObject);
            gameUI.RemuveHeart();
            Damage();
            sprite.color = colorDamage;
            Invoke("ResetMaterial", 0.5f);
        }
        if (collision.tag == "SpicesEnemy")
        {
            life -= 1;
            //SavePlayer();
            gameUI.RemuveHeart();
            Damage();
            sprite.color = colorDamage;         
            Invoke("ResetMaterial", 0.5f);
        }
        if (collision.tag == "Key")
        {
            key += 1;
            Destroy(collision.gameObject);
        }
    }
   /* private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SpicesEnemy")
        {
            ResetMaterial();
        }
    }*/
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "Platform")
        {
            this.transform.parent = collision.transform;
        }
        /*if (collision.transform.tag == "Silver")
        {
            silvercount++;
            textCoint.text = coins.ToString();
            Destroy(collision.gameObject);
        }*/
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            this.transform.parent = null;
        }

    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Rigidbody2D tempSilver = Instantiate(silver, transform.position, Quaternion.identity);
            tempSilver.AddForce(new Vector2(isRigth ? 400 : -400, 0));
            if (!isRigth)
            {
                SpriteRenderer srSilver = tempSilver.GetComponent<SpriteRenderer>();
                srSilver.flipX = true;
                srSilver.flipY = true;
            }
        }
    }

    /*public void SavePlayer()
    {
        GlobalControl.Instantiate.coins = coins;
        GlobalControl.Instantiate.life = life;
        GlobalControl.Instantiate.diamond = diamond;
    }*/
    void ResetMaterial()
    {
        sprite.color = Color.white;
    }
    private void Damage()
    {
        if (life == 0)
        {
            Time.timeScale = 0;
            gameUI.GameOver();
        }
    }

}
