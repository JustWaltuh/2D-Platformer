using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public enum States
{
    Idle,
    Run,
    Jump
}

public class Hero : MonoBehaviour
{
    private float _speed = 5f;
    private float _jumpForce = 17.5f;
    private float _dashForce = 6f;
    [SerializeField] private float _checkGroundTime;
    [SerializeField] private int _lives = 5;
    [SerializeField] public int _health;
    [SerializeField] private bool _isGrounded = false;

    private CircleCollider2D _circleCollider;
    private CapsuleCollider2D _capsuleCollider;


    [SerializeField] public GameObject _inGameMenu;

    [SerializeField] private SpriteRenderer[] _hearts;
    [SerializeField] private Sprite _aliveHeart;
    [SerializeField] private Sprite _deadHeart;

    [SerializeField] private SpriteRenderer[] _dashes;
    [SerializeField] private Sprite _enabledDash;
    [SerializeField] private Sprite _disabledDash;



    public static Hero Instance { get; set; }

    public bool _invincible = false;
    private bool _isDead = false;

    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private Animator _anim;

    private Vector3 _dir;
    [SerializeField] private int _dashAmount = 3;

    private States State
    {
        get { return (States)_anim.GetInteger("State"); }
        set {_anim.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        _health = _lives;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _capsuleCollider = GetComponentInChildren<CapsuleCollider2D>();

        Instance = this;
    }

    private void Update()
    {
        if (_isGrounded)
        {
            _checkGroundTime = 0f;
            State = States.Idle;
        }

        if (Input.GetButton("Horizontal")) Run();
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) Jump();
        if (Input.GetKeyDown(KeyCode.LeftShift)) Dash();

        if (_lives > 5) _lives = 5;

        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < _health) _hearts[i].sprite = _aliveHeart;
            else _hearts[i].sprite = _deadHeart;
        }

        for (int i = 0; i < _dashes.Length; i++)
        {
            if (i < _dashAmount) _dashes[i].sprite = _enabledDash;
            else _dashes[i].sprite = _disabledDash;
        }

        if (_health <= 0) Death();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Run()
    {
        if (!_isDead)
        {
            if (_isGrounded) State = States.Run;

            _dir = transform.right * Input.GetAxis("Horizontal");
            transform.position = Vector3.MoveTowards(transform.position, transform.position + _dir, _speed * Time.deltaTime);
            _sprite.flipX = _dir.x < 0.0f;
        }
    }

    private void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce/1.5f, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        _isGrounded = collider.Length > 1;

        if (!_isGrounded)
        {
            _checkGroundTime += Time.fixedDeltaTime;
            State = States.Jump;
        }
    }

    public void GetDamage()
    {

        _lives -= 1;
        _health = _lives;


        StartCoroutine(InvincibleMethod());
    }

    private IEnumerator InvincibleMethod()
    {
        _invincible = true;
        _sprite.color = new Color(1, 1, 1, 0.5f);

        yield return new WaitForSeconds(3f);

        _invincible = false;
        _sprite.color = new Color(1, 1, 1, 1);
    }

    public void GetForced(float _pushForce)
    {
        _rb.AddForce(transform.up * (_pushForce + _checkGroundTime * 10), ForceMode2D.Impulse);
    }

    private void Death()
    {
        _isDead = true;

        Vector2 deathDir = transform.position;
        deathDir.y += 10f;

        _inGameMenu.SetActive(true);

        DestroyImmediate(_capsuleCollider);
        DestroyImmediate(_circleCollider);
        transform.position = Vector2.Lerp(transform.position, deathDir, Time.deltaTime);

        Destroy(gameObject, 2f);
    }

    public void GetHealth()
    {
        _lives += 1;
        _health = _lives;
    }

    private void Dash()
    {
        _rb.AddForce(transform.right * _dir.x * _dashForce, ForceMode2D.Impulse);
        _dashAmount -= 1;
        StartCoroutine(DashRefill());
    }

    private IEnumerator DashRefill()
    {
        yield return new WaitForSeconds(5f);
        _dashAmount += 1;
    }
}
