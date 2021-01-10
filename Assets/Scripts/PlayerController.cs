using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.5f;
    public Transform groundPoint;
    public LayerMask groundLayer;
    public float groundRadius;
    public float jumpForce = 2.5f;
    public float longIdleTime = 4;
    public float flinchTime = 1.2f;
    bool _isHit=false;
    float timeHit;
    //Refs
    Rigidbody2D _myRigidbody;
    Animator _myAnimator;
    //Movement
    Vector2 _movement;
    bool _facingRight = true;
    bool isGrounded;
    //Attack
    bool isAttacking;
    float longIdleTimer = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        _myAnimator = GetComponent<Animator>();
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking == false)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            _movement = new Vector2(horizontalInput, 0f);
            if (horizontalInput < 0f && _facingRight == true)
            {
                flip();
            }
            else if (horizontalInput > 0f && _facingRight == false)
            {
                flip();
            }
        }

        isGrounded = Physics2D.OverlapCircle(groundPoint.position, groundRadius, groundLayer);
        if (Input.GetButtonDown("Fire1") && isAttacking != true)
        {
            _movement = Vector2.zero;
            _myAnimator.SetTrigger("Attack");
        }
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            _myRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


    }

    void FixedUpdate()
    {
        if (isAttacking == true)
        {
            if (isGrounded == true)
            {
                _myRigidbody.velocity = new Vector2(0, _myRigidbody.velocity.y);
            }
            else
            {
                _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x, _myRigidbody.velocity.y);
            }
        }
        else
        {
            float horizontalVelocyty = _movement.normalized.x * speed;
            _myRigidbody.velocity = new Vector2(horizontalVelocyty, _myRigidbody.velocity.y);
        }
    }

    void LateUpdate()
    {
        _myAnimator.SetBool("isGrounded", isGrounded);
        _myAnimator.SetFloat("VerticalSpeed", _myRigidbody.velocity.y);
        _myAnimator.SetBool("Idle", _movement == Vector2.zero);

        if (_myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
        if (_myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            longIdleTimer += Time.deltaTime;
            if (longIdleTimer >= longIdleTime)
            {
                _myAnimator.SetTrigger("LongIdle");
            }

        }
        else
        {
            longIdleTimer = 0;
        }

    }

    void flip()
    {
        _facingRight = !_facingRight;
        float localScale = transform.localScale.x;
        localScale = localScale * -1;
        transform.localScale = new Vector3(localScale, transform.localScale.y, transform.localScale.z);

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyScript>())
        {
            if (_isHit == false)
            {
                timeHit = Time.time;
                _isHit = true;
                var takeDamage = GetComponentInChildren<PlayerHealth>();
                takeDamage.addDamage(1);
            }
            
            if (_isHit==true)
            {
                float timePassed = Time.time - timeHit;
                if (timePassed > flinchTime) { 
                    _isHit = false;
                    timePassed = 0;
                }
            }
            
            
        }
    }
}
