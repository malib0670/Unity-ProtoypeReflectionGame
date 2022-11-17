using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    private float spawnRate = 1.0f;
    private int score;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startMethod(int difficulty)
    {
        isGameActive = true;
        score = 0;
        updateScore(0); 
        spawnRate /= difficulty; 
                                    
    }

    IEnumerator spawnTarget() 
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate); 
            int index = Random.Range(0, targets.Count); 
            Instantiate(targets[index]);
        }
    }

    public void updateScore(int addToScore)
    {
        score += addToScore;
        scoreText.text = "Score: " + score;
    }

    public void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive=false; 
        restartButton.gameObject.SetActive(true);
    }

    public void restartGame() 
    {                                                                           
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void startGame(int difficulty)
    {
        startMethod(difficulty);
        StartCoroutine(spawnTarget());
        titleScreen.gameObject.SetActive(false);
    }
}
