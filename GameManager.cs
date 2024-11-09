using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemyOne;
    public GameObject cloud;
    public GameObject HealthPUp;
    public TextMeshProUGUI scoreText;
    public GameObject enemyTwo;
    public GameObject enemyThree;
    public TextMeshProUGUI livesText;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemyOne", 1f, 3f);
        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;
        InvokeRepeating("CreateHPUp", 3f, 10f);
        InvokeRepeating("CreateEnemyTwo", 1f, 6f);
        InvokeRepeating("CreateEnemyThree", 2f, 7f);
        livesText.text = "Lives: 3";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOne, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwo, new Vector3(-11f, Random.Range(-2f, 9f), 0), Quaternion.Euler(0, 0, -90));
    }

    void CreateEnemyThree()
    {
        Instantiate(enemyThree, new Vector3(11f, Random.Range(-2f, 9f), 0), Quaternion.Euler(0, 0, 115));
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    public void EarnScore(int newScore)
    {
        score = score + newScore;
        scoreText.text = "Score: " + score;
    }

    void CreateHPUp()
    {
        Instantiate(HealthPUp, new Vector3(Random.Range(-8f, 8f), Random.Range(-8f, 8f), 0), Quaternion.identity);
    }

    public void LoseLifeText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }

}
