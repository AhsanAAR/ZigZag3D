using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{

    public static bool gameOver;
    public static gameManager instance;
    public GameObject ball;



    public Camera cam;

    public AudioClip moveSound;
    public AudioClip diamondSound;
    public AudioClip fallSound;
    public AudioClip startSound;

    public void changeZoom(float size)
    {
        cam.orthographicSize = size;
    }

    bool gameStart;
    public static bool fall;

   

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        soundManager.instance.playSound(startSound);
        fall = true;
        gameOver = false;
        gameStart = false;
        Invoke("startDelay", 1f);
        InvokeRepeating("changeBallColor",0.5f,0.7f);
    }


    void startDelay()
    {
        fall = false;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.constraints = RigidbodyConstraints.FreezePositionY;
    }

    void changeBallColor()
    {
        scoreManager.newColor = scoreManager.randomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (!fall && !gameStart && Input.anyKeyDown)
        {
            startGame();
        }

        if(!fall && gameOver && Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
    }


    public void startGame()
    {
        CancelInvoke("changeBallColor");
        gameStart = true;
        UIManager.instance.gameStart();
        platformSpawner.instance.spawnInitial();
        scoreManager.instance.gameStart();
    }

    void endDelay()
    {
        fall = false;
    }

    bool soundPlayed = false;

    public void endGame()
    {
        if (!soundPlayed)
        {
            soundManager.instance.playSound(fallSound);
            soundPlayed = true;
        }
        Invoke("endDelay",0.01f);
        gameOver = true;
        UIManager.instance.gameOver();
        scoreManager.instance.gameEnd();
    }

}
