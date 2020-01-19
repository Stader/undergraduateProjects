using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class MoverPlayer : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Rigidbody2D _rb2d;
    private Animator _ani;
    [SerializeField] private float velocidade = 5.0f;
    [SerializeField] private float forcaPulo = 5.0f;
    private Vector3 movement;
    private bool inStairs = false;

    public bool canMove = true;
    public LayerMask plataforma;
    public Vector2 pontoColisaoPiso = Vector2.zero;
    public bool estaNoChao;
    public float raio;
    public Color debugColisao = Color.red;


    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _rb2d = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
        _sprite.flipX = false;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float jump = Input.GetAxisRaw("Jump");
        if (!estaNoChao)
            jump = 1.0f;
        if (canMove)
        {
            Move(h);
            InTheGround();
            Animar(h, jump);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Pular();
            }
        }
        else
        {
            _rb2d.velocity = new Vector2(velocidade * 1, _rb2d.velocity.y);
            _sprite.flipX = false;
            _ani.SetBool("isWalking", true);
            _ani.SetBool("isJumping", false);
        }

        if (inStairs)
        {
            _rb2d.gravityScale = 0.0f;
            Vector3 escada = new Vector3(h, v, 0.0f);
            transform.Translate(escada * Time.deltaTime * (velocidade/2));
        }
        else
        {
            _rb2d.gravityScale = 1.0f;
        }
    }

    void Move(float h)
    {
        _rb2d.velocity = new Vector2(velocidade * h, _rb2d.velocity.y);
    }

    void Animar(float h, float jump)
    {
        bool walking = h != 0f;
        bool jumping = jump != 0f;

        if (Input.GetAxis("Horizontal") > 0.2f)
        {
            _sprite.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.2f)
        {
            _sprite.flipX = true;
        }

        _ani.SetBool("isWalking", walking);
        _ani.SetBool("isJumping", jumping);
    }

    void Pular()
    {
        if (estaNoChao && _rb2d.velocity.y <= 0)
        {
            _rb2d.AddForce(new Vector2(_rb2d.velocity.x, forcaPulo), ForceMode2D.Impulse);
        }
    }

    private void InTheGround()
    {
        var pontoPosicao = pontoColisaoPiso;
        pontoPosicao.x += transform.position.x;
        pontoPosicao.y += transform.position.y;
        estaNoChao = Physics2D.OverlapCircle(pontoPosicao, raio, plataforma);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = debugColisao;
        var pontoPosicao = pontoColisaoPiso;
        pontoPosicao.x += transform.position.x;
        pontoPosicao.y += transform.position.y;
        Gizmos.DrawWireSphere(pontoPosicao, raio);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Escada"))
        {
            inStairs = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Escada"))
        {
            inStairs = false;
        }
    }
}
