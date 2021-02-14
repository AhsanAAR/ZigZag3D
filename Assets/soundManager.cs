using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject ball;

    public static soundManager instance;

    public void playSound(AudioClip sound)
    {
        //audioSource.transform.position = ball.transform.position;
        audioSource.PlayOneShot(sound);
    }


    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
