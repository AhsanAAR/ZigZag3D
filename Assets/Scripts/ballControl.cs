using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControl : MonoBehaviour
{
    public static float speed = 0;

    public GameObject particle;

    private bool z = false;

    Rigidbody ballBody;
    AudioSource audioSource1;

    private void Awake()
    {
        ballBody = GetComponent<Rigidbody>();
        audioSource1 = GetComponent<AudioSource>();
    }



    // Start is called before the first frame update
    void Start()
    {
        speed = 9;
        ballBody.velocity = new Vector3(0,0,0);
    }

    void endDelay()
    {
        gameManager.fall = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ( !gameManager.fall && ! Physics.Raycast(transform.position, Vector3.down, 5f))
        {
            ballBody.constraints = RigidbodyConstraints.None;
            ballBody.AddForce(0,-50,0);
            Destroy(gameObject, 1.5f);
            gameManager.fall = true;
            gameManager.instance.endGame();
        }

        if (Input.anyKeyDown && !gameManager.fall && !gameManager.gameOver) 
        {
            switchVelocity();
            scoreManager.instance.increment();
        }
    
    }


    void switchVelocity()
    {
        soundManager.instance.playSound(gameManager.instance.moveSound);
        if (z)
        {
            z = false;
            ballBody.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            z = true;
            ballBody.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "diamond")
        {
            soundManager.instance.playSound(gameManager.instance.diamondSound);
            GameObject PS = Instantiate(particle, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(PS, 1);
            scoreManager.instance.increment();
            scoreManager.instance.increment();
            scoreManager.instance.increment();
        }
    }

}
