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
        CheckUngrap();
        GetImpulse();
        GetShoot();
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
    }
    public void CheckUngrap()
    {
        if (Input.GetMouseButton(1))
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
    public void GetImpulse()
    {
        if (Input.GetButtonDown("VImpulse"))
        {
            Debug.Log("Fuerza");
            player.SetForce();
        }
    }
    public void GetShoot()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.Shoot();
        }
    }
}
