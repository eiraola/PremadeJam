using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Camera cam;
    public SpriteRenderer sprite;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Vector2 aim = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (dir.x>transform.position.x) { 
            sprite.transform.localScale = sprite.transform.localScale = new Vector3(sprite.transform.localScale.x, 1, sprite.transform.localScale.z);
        }
        else
        {
            sprite.transform.localScale = sprite.transform.localScale = new Vector3(sprite.transform.localScale.x, -1, sprite.transform.localScale.z);
        }
    }
    public void Shoot()
    {
        Instantiate(Bullet, transform.position, transform.rotation).transform.RotateAround(transform.position, Vector3.forward, 180f); ;
    }
    
}
