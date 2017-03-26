using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class GameController : MonoBehaviour {

    //public GameObject hazard;
    //public Vector3 spawnValues;
    //public int hazardCount;
    //public float spawnWait;
    //public float startWait;
    //public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    //private bool gameOver;
    private bool restart; 
    public int score; 

    void Start()
    {
        //gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        //StartCoroutine (SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            restartText.text = "Press 'R' to restart";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    /*
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0f, spawnValues.z);
                Quaternion spawnRoatation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRoatation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }  
    }
    */
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score; 
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        //gameOver = true;
        restart = true;
    }
}
