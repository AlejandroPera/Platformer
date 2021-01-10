using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("An object with name:" + collision.gameObject.name + "Has entered my area");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("An object with name:" + collision.gameObject.name + "Is in my area");

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("An object with name:" + collision.gameObject.name + "Has exit my area");

    }
}
