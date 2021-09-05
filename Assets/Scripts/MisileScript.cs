using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisileScript : MonoBehaviour
{
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.right* speed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.Damaged();
            Destroy(gameObject);
        }
    }
}
