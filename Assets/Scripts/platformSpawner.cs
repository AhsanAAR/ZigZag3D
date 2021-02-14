using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class platformSpawner : MonoBehaviour
{

    public GameObject platform;
    public GameObject diamond;

    public Material material;

    public static Color newColor;

    public static platformSpawner instance;

    Vector3 lastPos;
    float size;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
    }

    public void spawnInitial()
    {
        for (int i = 0; i < 15; i++)
        {
            spawnRandom();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver)
            CancelInvoke("spawnRandom");
    }


    public void spawnRandom()
    {
        int choice = Random.Range(0, 20);
        if(choice < 10)
        {
            spawnX();
        }
        else
        {
            spawnZ();
        }

        if(choice == 5 || choice == 15)
        { 
            spawnDiamond();
        }
    }
    void spawnDiamond()
    {
        Vector3 diamondPos = lastPos;
        diamondPos.y = 2f;
        Instantiate(diamond, diamondPos,diamond.transform.rotation);
    }


    void spawnX()
    {
        Vector3 newPos = lastPos;
        newPos.x += size;
        lastPos = newPos;
        Instantiate(platform, lastPos, Quaternion.identity);
    }

    void spawnZ()
    {
        Vector3 newPos = lastPos;
        newPos.z += size;
        lastPos = newPos;
        Instantiate(platform, lastPos, Quaternion.identity);
    }
}
