using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int totalHealth=1;
    int health;
    int damage = 1;

    private void Start()
    {
        health = totalHealth;
    }
    // Start is called before the first frame update
    public void addDamage()
    {
        health = health - damage;
        //if(health==0){gameObject.SetActive(false);}
        gameObject.SetActive(false);
    }
}

