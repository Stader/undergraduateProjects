using UnityEngine;

public class DinoIA : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private BoxCollider2D _collider;
    public IAManager iaManager;

    public float speed = 3f;
    private float originalSpeed;
    public float jumpForce = 6f;

    public float distanceCheckJump = 1f, distanceCheckCrouch = .5f, mutation;


    private readonly float timeToJump = 0.55f;
    private float canJump;
    private RaycastHit2D hitFloor, hitCrouch;
    private bool isCrouch, die = false;

    private float timer;

    void Start()
    {
        originalSpeed = speed;
        distanceCheckCrouch = Random.Range(distanceCheckCrouch - distanceCheckCrouch * (mutation / 100), distanceCheckCrouch + distanceCheckCrouch * (mutation / 100));
        distanceCheckJump = Random.Range(distanceCheckJump - distanceCheckJump * (mutation / 100), distanceCheckJump + distanceCheckJump * (mutation / 100));
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(!die)
            speed = originalSpeed + timer / 1000;
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        CheckRayCastJump();
        Crouch();
        RunAnimation();
        if(transform.position.y < -50f && !die)
        {
            Die();
        }
    }

    private void CheckRayCastJump()
    {
        var floorPosition = transform.position - new Vector3(0f, 0.125f, 0f);
        var crouchPosition = transform.position + new Vector3(-0.225f, 0.2f, 0f);

        Debug.DrawLine(floorPosition, (Vector2)floorPosition + Vector2.right * distanceCheckJump, Color.yellow);
        Debug.DrawLine(crouchPosition, (Vector2)crouchPosition + Vector2.right * distanceCheckCrouch, Color.red);

        hitFloor = Physics2D.Linecast(floorPosition, (Vector2)floorPosition + Vector2.right * distanceCheckJump, 1 << LayerMask.NameToLayer("Object"));
        hitCrouch = Physics2D.Linecast(crouchPosition, (Vector2)crouchPosition + Vector2.right * distanceCheckCrouch, 1 << LayerMask.NameToLayer("Object"));

        if (hitFloor)
            Jump();
        else if (hitCrouch)
        {
            if (hitCrouch.collider.gameObject.CompareTag("Enemy"))
            {
                isCrouch = true;
            }
        }
        else
            isCrouch = false;
    }

    private void Jump()
    {
        if (Time.time > canJump && !isCrouch)
        {
            _anim.SetInteger("Animation", 1);
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = Time.time + timeToJump;
        }
    }

    private void Crouch()
    {
        if (isCrouch)
        {
            _anim.SetInteger("Animation", 2);
        }
    }

    private void RunAnimation()
    {
        if (_rb.velocity.y == 0f && !isCrouch)
        {
            _anim.SetInteger("Animation", 0);
        }
    }

    private void NormalCollisor()
    {
        _collider.offset = new Vector2(0, 0.01f);
        _collider.size = new Vector2(0.41f, 0.44f);
    }
    private void CrouchCollisor()
    {
        _collider.offset = new Vector2(0, -0.08f);
        _collider.size = new Vector2(0.55f, 0.26f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dino"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dino"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
        else if (collision.CompareTag("Floor"))
        {
            
        }
        else if(!die)
        {
            Die();
        }
    }

    private void Die()
    {
        die = true;
        iaManager.newDistanceCheckCrouch = distanceCheckCrouch;
        iaManager.newDistanceCheckJump = distanceCheckJump;
        iaManager.remainDinos--;
        speed = 0f;
        Destroy(gameObject, 0.5f);
    }
}
