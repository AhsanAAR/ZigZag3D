using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject gameOverPanel;
    public GameObject zigZagPanel;
    public GameObject tapText;

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameStart()
    {
        zigZagPanel.GetComponent<Animator>().Play("panelUp");
        tapText.GetComponent<Animator>().Play("textDown");
    }


    public void gameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
