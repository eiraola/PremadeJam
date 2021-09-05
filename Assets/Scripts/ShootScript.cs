using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public float speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.right* speed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("XDXDXDXDX");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
