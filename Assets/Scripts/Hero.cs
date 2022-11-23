using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private Rigidbody2D silverWeapon;
    [SerializeField] private Color colorDamage;
    private bool isRigth = true;
    private bool isGrounded = false;
    public int coins = 0;
    public int life = 5;
    public int key = 0;
    public int diamond = 0;
    public int silver = 0;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    //private Animator anim;

    public int Key
    {
        get => key;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        //anim = GetComponent<Animator>();
        SceneManager.sceneLoaded += LevelLoaded;//підписка на подію завантаження сцени
    }
    void Start()
    {
        SetValueInUI();
    }
    void SetValueInUI()
    {
        gameUI.SetCountCoinUI(coins);
        gameUI.SetCountDiamondUI(diamond);
        gameUI.SetCountSilverUI(silver);
        gameUI.SetCountLifeUI(life);
    }
    private void LevelLoaded(Scene scene,LoadSceneMode mode)
    {
        if(SingletoneHero.singletoneHero.transform==transform)
        {
            gameUI = FindObjectOfType<GameUI>();
            SetValueInUI();
        }
    }
    public void NewStartParametr()
    {
        coins = 0;
        diamond = 0;
        silver = 0;
        life = 5;
        SetValueInUI();
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
    public void Run()
    {
        float move = Input.GetAxis("Horizontal");
        Vector3 dir = transform.right * move;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        Flip(move);
    }

    public void Jump()
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
            gameUI.SetCountCoinUI(coins);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Silver")
        {
            silver += 1;
            gameUI.SetCountSilverUI(silver);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Heart")
        {
            life += 1;
            gameUI.AddHeart();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Diamond")
        {
            diamond += 5;
            gameUI.SetCountDiamondUI(diamond);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Enemy")
        {           
            Damage();
            Destroy(collision.gameObject);
            sprite.color = colorDamage;
            Invoke("ResetMaterial", 0.5f);
        }
        if (collision.tag == "SpicesEnemy")
        {       
            Damage();
            sprite.color = colorDamage;
            Invoke("ResetMaterial", 0.5f);
        }
        if (collision.tag == "RestartStartPoint")
        {
            Damage();            
        }
        if (collision.tag == "Key")
        {
            key += 1;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "Platform")
        {
            transform.parent = collision.transform;
        }
        if (collision.transform.tag == "Zombie")
        {           
            Damage();
            sprite.color = colorDamage;
            Invoke("ResetMaterial", 0.5f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            transform.parent = null;
        }
    }
    
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Return) && silver > 0)
        {
            silver--;
            gameUI.SetCountSilverUI(silver);
            Rigidbody2D tempSilver = Instantiate(silverWeapon, transform.position, Quaternion.identity);
            tempSilver.AddForce(new Vector2(isRigth ? 300 : -300, 0));
            if (!isRigth)
            {
                SpriteRenderer srSilver = tempSilver.GetComponent<SpriteRenderer>();
                srSilver.flipX = true;
                srSilver.flipY = true;
            }
        }
    }

    void ResetMaterial()
    {
        sprite.color = Color.white;
    }

    private void Damage()
    {
        life -= 1;
        gameUI.RemuveHeart();

        if (life == 0)
        {
            Time.timeScale = 0;
            gameUI.GameOver();
        }
    }

}
