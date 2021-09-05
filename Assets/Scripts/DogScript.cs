using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    // Start is called before the first frame update
    SoundSource soundSource;
    void Start()
    {
        soundSource = FindObjectOfType<SoundSource>();
        soundSource.Play("Bark");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.GetADog();
            soundSource.Play("Bark");
            if (player.HasAllDogs())
            {
                Debug.Log("fin del juego");
            }
            Destroy(gameObject);
        }
    }
}
