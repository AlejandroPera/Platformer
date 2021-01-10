using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform _firepoint;
    public GameObject shooter;
    private int _counter=0;
    private float _random=1;


    void Awake()
    {
        _firepoint = transform.Find("FirePoint");
 
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void Shoot()
    {   if (_counter % 2 == 0)
        {
            bulletPrefab = Resources.Load("Big bullet") as GameObject;
        }
        else
        {
            bulletPrefab = Resources.Load("Bullet") as GameObject;
        }
        
        if (bulletPrefab!=null && _firepoint != null && shooter!=null){
            
            GameObject myBullet = Instantiate(bulletPrefab, _firepoint.position, Quaternion.identity) as GameObject;
            Bullet bulletComponent = myBullet.GetComponent<Bullet>();
            if (shooter.transform.localScale.x > 0f)
            {
                bulletComponent.directtion = Vector2.right;
                //bulletComponent.sin_movement = 1;
            }
            else
            {
                bulletComponent.directtion = Vector2.left;
                //bulletComponent.sin_movement = -1;
            }
            //bulletComponent.movimiento = _counter;
            _counter += 1;
            //_random = Random.Range(_random+0.1f, _random + 0.2f);
            //yield return new WaitForSeconds(_random);
            //StartCoroutine("Shoot");
        }
    }
}
