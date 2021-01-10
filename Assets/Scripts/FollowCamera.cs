using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform character;
    public Vector3 offset;
    float speed=0.125f;
    float minx=-0.5f;
    float maxx=0.6f;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        if (character.position.x < maxx && character.position.x > minx) { 
        Vector3 desiredPosition = character.position + offset;
        Vector3 SmoothPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = SmoothPosition;
        }
    }
}
