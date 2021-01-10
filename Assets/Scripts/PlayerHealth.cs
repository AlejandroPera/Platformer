using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public RectTransform healthUI;
    public int totalHealth = 3;
    int health;
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject rewind;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    private void Awake()
    {   
        sprite = GetComponentInParent<SpriteRenderer>();
    }

    void Start()
    {
        health = totalHealth;
        StartCoroutine("Rewind");
    }

    // Update is called once per frame
    void Update()
    {
        //if (health == 0)
        //{
        //transform.parent.gameObject.SetActive(false);
        //}
    }
    public void addDamage(int amount)
    {
        health = health-amount;
        print("Hit");
        StartCoroutine("VisualFeedback");
        if (health == 2)
        {
            health1.SetActive(false);
        }
        else if (health == 1)
        {
            health2.SetActive(false);
        }
        else if (health == 0)
        {
            health3.SetActive(false);
        }
        
    }
    public void addHealth(int amount)
    {
        if (health < totalHealth) { 
        health += amount;
        }
        if (health == 3)
        {
            health1.SetActive(true);
        }
        else if (health == 2)
        {
            health2.SetActive(true);
        }
        


    }

    IEnumerator VisualFeedback()
    {
        Color damage = new Color(0.7735849f, 0.294838f, 0.3355491f);
        sprite.color = damage;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    IEnumerator Rewind()
    {
        rewind.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        rewind.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        rewind.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        rewind.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        rewind.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        rewind.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        rewind.SetActive(false);
        yield return new WaitForSeconds(0.06f);
        rewind.SetActive(true);
        yield return new WaitForSeconds(0.06f);
        rewind.SetActive(false);
  
    }
}
