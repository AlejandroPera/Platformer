using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingKeys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //Mouse
       if (Input.GetMouseButtonDown(0)){
            Debug.Log("Button pressed");
        }
        if (Input.GetMouseButton(1))
        {
            Debug.Log("Button is pressed");
        }
        if (Input.GetMouseButtonUp(2))
        {
            Debug.Log("Button released");
        }
        if (Input.GetMouseButtonDown(3))
        {
            Debug.Log("Button 4 pressed");
        }
        if (Input.GetMouseButtonDown(4))
        {
            Debug.Log("Button 5 pressed");
        }
        if (Input.GetMouseButtonDown(5))
        {
            Debug.Log("LOL");
        }

        //Keyboard
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
        }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Space pressed");
        }

        //GetAxis

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal < 0f || horizontal>0f)
        {
            Debug.Log(horizontal);
        }
        if (vertical < 0f || vertical > 0f)
        {
            Debug.Log(vertical);
        }

    }   

}
