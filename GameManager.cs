using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemyOne;
    public GameObject cloud;
    public GameObject powerup;
    public GameObject enemyTwo;
    public GameObject enemyThree;
    public GameObject Coin;
    public GameObject HealthPUp;


    public AudioClip powerUp;
    public AudioClip powerDown;

    public int cloudSpeed;

    private bool isPlayerAlive;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI powerupText;
    public TextMeshProUGUI livesText;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemyOne", 1f, 3f);
        StartCoroutine(CreatePowerup());
        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;
        InvokeRepeating("CreateHPUp", 3f, 10f);
        InvokeRepeating("CreateEnemyTwo", 1f, 6f);
        InvokeRepeating("CreateEnemyThree", 2f, 7f);
        livesText.text = "Lives: 3";
        InvokeRepeating("CreateCoin", 2f, 6f);
        isPlayerAlive = true;
        cloudSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Restart();   
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

    IEnumerator CreatePowerup()
    {
        Instantiate(powerup, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3f, 6f));
        StartCoroutine(CreatePowerup());
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
        Instantiate(HealthPUp, new Vector3(Random.Range(-8f, 8f), Random.Range(-5f, 0f), 0), Quaternion.identity);
    }

    void CreateCoin()
    {
        Instantiate(Coin, new Vector3(Random.Range(-8f, 8f), Random.Range(-5f, 0f), 0), Quaternion.identity);
    }

    public void LoseLifeText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }

    public void GameOver()
    {
        isPlayerAlive = false;
        CancelInvoke();
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        cloudSpeed = 0;
    }

    void Restart()
    {
        if(Input.GetKeyDown(KeyCode.R) && isPlayerAlive == false)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void UpdatePowerupText(string whichPowerup)
    {
        powerupText.text = whichPowerup;
    }

    public void PlayPowerUp()
    {
        AudioSource.PlayClipAtPoint(powerUp, Camera.main.transform.position);
    }

    public void PlayPowerDown()
    {
        AudioSource.PlayClipAtPoint(powerDown, Camera.main.transform.position);
    }
}
