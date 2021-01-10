using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public int respawnTime = 6;
    public int enemyInPool = 3;
    void Start()
    {
        initializePool();
        InvokeRepeating("invokeEnemy", 1f, respawnTime);
    }

    void initializePool()
    {
        for (int i = 0; i < enemyInPool; i++)
        {
            addEnemyToPool();
        }
    }
    void addEnemyToPool()
    {
        GameObject inst = Instantiate(enemy, this.transform.position,Quaternion.identity, this.transform);
        inst.SetActive(false);
    }

    private void invokeEnemy()
    {
        GameObject inst=null;
        for(int s = 0; s < transform.childCount; s++)
        {
            if (!transform.GetChild(s).gameObject.activeSelf)
            {
                inst = transform.GetChild(s).gameObject;
                break;
            }
        }
        if (inst == null)
        {
            addEnemyToPool();
            enemy = transform.GetChild(transform.childCount-1).gameObject;
        }

        inst.transform.position = this.transform.position;
        inst.SetActive(true);
        
    }
}
