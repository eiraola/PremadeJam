using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
    public AudioClip Track;
    public string name;
    [Range(0.0f,1.0f)]
    public float volume;
    [Range(0.1f, 3.0f)]
    public float pitch;
    public bool Loop;
    [HideInInspector]
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
