using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2000000.0f;
    Rigidbody2D body;
    Vector2 vel = Vector2.zero;
    public Camera cam;
    public LineRenderer line;
    public DistanceJoint2D joint;
    bool bIsGrappling = false;
    Animator anim;
    public GameObject LeftMarker, RightMarker;
    public LayerMask IgnoreMe;
    bool bRIslanded = false, bLIsLanded = false;
    Vector2 jumpForce;
    SpriteRenderer sprite;
    Vector2 objective;
    bool isObjectiveLocked = false;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
       body = GetComponent<Rigidbody2D>();
       // line = GetComponent<LineRenderer>();
       // joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckLanding();
    }
    private void FixedUpdate()
    {
        Vector2 velY = GetJumpSpeed();
        //vel =Vector2.Lerp(body.velocity, vel, 0.2f * Time.deltaTime);
        if (!bIsGrappling)
        {
            anim.SetBool("Walking", false);
           if (Mathf.Abs(vel.x) > 0.1 && IsLanded()) anim.SetBool("Walking",true) ;
            body.velocity = new Vector2(vel.x, velY.y);
        }
       
    }
    public void SetVelocity(float x, float y)
    {
        sprite.transform.localScale = new Vector2( x / Mathf.Abs(x), sprite.transform.localScale.y);
        vel = new Vector2(x, y) * speed * Time.deltaTime;
    }
    public void Grap()
        
    {
        Vector2 aim = cam.ScreenToWorldPoint(Input.mousePosition);
        line.SetPosition(0, aim);
        line.SetPosition(1, transform.position);
        joint.connectedAnchor = aim;
        joint.enabled = true;
        line.enabled = true;
        bIsGrappling = true;
    }
    public void Ungrap()
    {
        line.enabled = false;
        joint.enabled = false;
        bIsGrappling = false;
    }
    public void CheckLanding()
    {
        bRIslanded = false;
        bLIsLanded = false;

        RaycastHit2D hit = Physics2D.Raycast(LeftMarker.transform.position, -Vector2.up, 0.1f, ~IgnoreMe);
        if (hit.collider != null)
        {
            bLIsLanded = true;
            Debug.DrawRay(LeftMarker.transform.position, Vector3.down * hit.distance, Color.yellow);
        } 
       
        RaycastHit2D hit2 = Physics2D.Raycast(RightMarker.transform.position, -Vector2.up, 0.1f, ~IgnoreMe);
        if (hit.collider != null)
        {
            bRIslanded = true;
            Debug.DrawRay(RightMarker.transform.position, Vector3.down * hit.distance, Color.yellow);
        }


    }
    public bool IsLanded()
    {
        return bLIsLanded || bRIslanded;
    }
    public void Jump()
    {
        if (!IsLanded()) return;
        jumpForce = new Vector2(0, 5.0f);
    }
    public Vector2 GetJumpSpeed()
    {
        if (jumpForce.magnitude < 0.2) return body.velocity;
        return jumpForce =Vector2.Lerp(jumpForce, Vector2.zero,0.1f);
    }
    public void SetObjective(Vector2 pos) {
        objective = pos;
        isObjectiveLocked = true;
    }
    public void SetOffObjective()
    {
        isObjectiveLocked = false;
    }
}
