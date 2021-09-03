using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    PlayerController player;
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckGrap();
        Jumping();
    }
    public void Movement()
    {
       
        float x = 0.0f, y = 0.0f;
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01f)
        {
            
            x = Input.GetAxis("Horizontal");
        }
        player.SetVelocity(x, y);
    }
    public void CheckGrap()
    {
        if (Input.GetMouseButton(0))
        {
            player.Grap();
        }
        else
        {
            player.Ungrap();
        }
    }
    public void Jumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            player.Jump();
       }
    }
}
