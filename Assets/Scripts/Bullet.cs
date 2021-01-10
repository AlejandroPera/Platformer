using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.3f;
    //public float frequency = 3f;
    //public float magnitude = 0.4f;
    //public Vector3 direction;
    public Vector2 directtion;
    //public int movimiento=0;
    //public int sin_movement;
    Rigidbody2D rb;
    public Color finalColor;
    //float horizontal = Input.GetAxis("Horizontal");
    // Start is called before the first frame update
    public float livingTime = 12f;
    private float _started;
    //private int _ack_movement;
    private bool _isReversed;

    private SpriteRenderer _renderer;

    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        _started = Time.time;
        //direction = transform.position;
        Destroy(gameObject, livingTime);
    }

    private void Update()
    {
        float _timeLiving = Time.time - _started;
        float percentage = _timeLiving / livingTime;
        _renderer.color = Color.Lerp(Color.white, Color.red, percentage);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //_ack_movement = movimiento % 2;
        //if (_ack_movement == 0)
        //{
            //while (_started < livingTime){
            //Sin();
        //}
        //if (_started == livingTime)
        //{
            //movimiento = 1;
        //}

        //else
        //{
            /*while (_started < livingTime) {*/
            Horizontal();
            //}
            /*if (_started == livingTime)
            {*/
            //movimiento = 0;
            //}
        //}
        

    }
    void Horizontal()
    {
        Vector2 movement = directtion.normalized * speed;
        //transform.position = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
        rb.velocity = new Vector2(directtion.normalized.x*speed,0);
    }

    /*void Sin()
    {
        direction += sin_movement * transform.right * Time.deltaTime * speed;
        transform.position = direction + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _isReversed==false)
        {
            collision.SendMessageUpwards("addDamage", 1);
            Destroy(gameObject);
        }
        if(_isReversed==true && collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("addDamage");
            Destroy(gameObject);
        }
    }
    
    public void addDamage()
    {
        _isReversed=true;
        directtion = directtion * -1;
    }
}
