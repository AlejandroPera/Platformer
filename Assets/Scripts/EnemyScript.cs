using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 0.5f;
    //public float waintingTime = 2.5f;
    public LayerMask ground;

    
    bool facingRight;
    int direction;
    float wallAware = 0.6f;
    bool _isAttacking;

    //private GameObject _direction;
    private Animator _animator;
    private Weapon _weapon;
    private Rigidbody2D _myRigidBody;
    // Start is called before the first frame update

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _weapon = GetComponentInChildren<Weapon>();
        _myRigidBody = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        if (transform.localScale.x > 0f)
        {
            facingRight = true;
        }
        else
        {
            facingRight = false;
        }
        //UpdateDirection();
        //StartCoroutine("PatrolToTarget");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 collide = Vector2.right;
        if (facingRight == false)
        {
            collide = Vector2.left;
        }
        if (_isAttacking == false) { 
            if (Physics2D.Raycast(transform.position, collide, wallAware,ground))
            {
                flip();
            }
        }

    }

    private void FixedUpdate()
    {
       
        if (facingRight)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        float horizontalMovement = direction * speed;
        if (_isAttacking)
        {
            horizontalMovement = 0;
        }
        _myRigidBody.velocity = new Vector2(horizontalMovement, _myRigidBody.velocity.y);
    }

    private void LateUpdate()
    {
        _animator.SetBool("Idle", _myRigidBody.velocity == Vector2.zero);
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& _isAttacking==false)
        {
            StartCoroutine("EnemyShoot");
        }
    }

    IEnumerator EnemyShoot()
    {

        _isAttacking = true;
        yield return new WaitForSeconds(0.2f);
        _animator.SetTrigger("Shoot");
        yield return new WaitForSeconds(0.2f);
        _isAttacking = false;
    }
    void CanShoot()
    {
        if (_weapon != null)
        {
            _weapon.Shoot();
        }
    }
    private void OnEnable()
    {
        _isAttacking = false;
    }

    private void OnDisable()
    {
        StopCoroutine("EnemyShoot");
        _isAttacking = false;
    }
}

/*
 *    private void UpdateDirection()
    {
        if (_direction == null)
        {
            _direction = new GameObject("Target");
            _direction.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
            return;
        }
        if (_direction.transform.position.x == minX)
        {
            _direction.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_direction.transform.position.x == maxX)
        {
            _direction.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private IEnumerator PatrolToTarget()
    {
        while (Vector2.Distance(transform.position, _direction.transform.position) > 0.05f)
        {
            _animator.SetBool("Idle", false);
            Vector2 direction = _direction.transform.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
            yield return null;
        }
        print("Target reached");
        transform.position = new Vector2(_direction.transform.position.x, transform.position.y);
        UpdateDirection();

        _animator.SetBool("Idle", true);
        _animator.SetTrigger("Shoot");

        print("Lets wait");
        yield return new WaitForSeconds(waintingTime);

        print("Changing direction");
        
        StartCoroutine("PatrolToTarget");

    }
    void CanShoot()
    {
        if (_weapon != null)
        {
            _weapon.StartCoroutine("Shoot");
        }
    }

*/

