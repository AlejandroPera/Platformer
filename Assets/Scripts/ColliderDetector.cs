using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("An object with name:" + collision.gameObject.name + "Has collisioned with me");

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("An object with name:" + collision.gameObject.name + "Is collisionning with me");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("An object with name:" + collision.gameObject.name + "Has stopped collisioning with me");
    }

}
