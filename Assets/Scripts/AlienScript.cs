using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject proyectile;
    GameObject player;
    public float ShootSpeed = 1.0f;
    float direction = -1;
    float offset = 0;
    SoundSource soundSource;
    // Start is called before the first frame update
    void Start()
    {
        soundSource = FindObjectOfType<SoundSource>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        StartCoroutine("ShootTimer");
    }
    public void OnDestroy()
    {
        soundSource.Play("Explosion");
        ManagerScript  manager = GameObject.FindGameObjectsWithTag("Manager")[0].GetComponent<ManagerScript>();
        manager.EnemyDied();
    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > 12.0f)
        {
            direction = direction * -1;
        }
        float sinY = Mathf.Sin((offset +transform.position.x) * 2);
        
        Vector3 dir = direction * (transform.right * speed * Time.deltaTime);
        Vector3 targetDir = new Vector3(dir.x, dir.y, dir.z);
        transform.Translate(dir);
        transform.position = new Vector3(transform.position.x, sinY, transform.position.z);
    }
    public void Shoot()
    {
        soundSource.Play("AlienShoot");
        Vector3 pos = transform.position;
        Vector3 dir = pos - player.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Instantiate(proyectile, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.Damaged();
        }
    }
    public void SetOffset(float x)
    {
        offset = x;
    }
    
    IEnumerator ShootTimer()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(ShootSpeed);
            Shoot();
        }
    }
}
