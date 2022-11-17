using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        buttonStartMethod();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonStartMethod()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(setDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void setDifficulty()
    {
        Debug.Log(button.gameObject.name + " was cliced");
        gameManager.startGame(difficulty); 
    }
}
