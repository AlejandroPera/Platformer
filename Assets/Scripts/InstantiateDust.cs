using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDust : MonoBehaviour
{
    public GameObject prefab;
    public Transform point;
    public float living_time;
    // Start is called before the first frame update
    public void Instantiate()
    {
        GameObject InstantiateObject = Instantiate(prefab, point.position, Quaternion.identity) as GameObject;

        if (living_time > 0f)
        {
            Destroy(InstantiateObject, living_time);
        }
    }
}
