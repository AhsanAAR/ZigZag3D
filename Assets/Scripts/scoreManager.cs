using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public Text homeHighScore;
    public Text scoreCounter;
    public Text gameOverScore;
    public Text gameOverHighScore;
    public Text highScoreText;

    public AudioClip levelUp;


    public static scoreManager instance;

    public static Color newColor;
    Renderer renderer;

    int score;
    int highscore;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        score = 0;
        renderer = gameManager.instance.ball.GetComponent<Renderer>();
        highscore = PlayerPrefs.GetInt("highscore", 0);
        homeHighScore.text = highscore.ToString();
    }

    public void gameStart()
    {
        scoreCounter.gameObject.SetActive(true);
    }

    public void gameEnd()
    {
        scoreCounter.gameObject.SetActive(false);
        if (score > highscore)
        {
            highscore = score;
            gameOverHighScore.color = Color.green;
            highScoreText.color = Color.green;
            PlayerPrefs.SetInt("highscore", highscore);
        }

        gameOverHighScore.text = highscore.ToString();
        gameOverScore.text = score.ToString();

    }

    public void increment()
    {
        score++;
        scoreCounter.text = score.ToString();
        if (score % 20 == 0)
        {
            if (score <= 100)
                ballControl.speed += 0.4f;
            else
                ballControl.speed += 0.2f;
            newColor = randomColor();
            soundManager.instance.playSound(levelUp);
        }
    }
    
    public static Color randomColor()
    {
        Color rand;
        rand.r = Random.Range(0f,1f);
        rand.g = Random.Range(0f, 1f);
        rand.b = Random.Range(0f, 1f);
        rand.a = 1;
        return rand;
    }


    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
            renderer.material.color = Color.Lerp(renderer.material.color, newColor, 0.05f);
        }
    }
}
