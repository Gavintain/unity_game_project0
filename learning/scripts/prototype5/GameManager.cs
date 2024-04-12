using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Xml.Serialization;

public class GameManager : MonoBehaviour{

    public List<GameObject> targets;
    private float spawnRate;
    public int score;
    public int defaultDifficulty;
    public bool IsGameActive;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton;
    void Start()
    {   
        InitiaizingGame();
        titleScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void InitiaizingGame()
    {
        IsGameActive = true;
        restartButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        spawnRate = 1.0f;
        score = 0;
        defaultDifficulty = 1;
        UpdateScore(0);
        
    }
    public void startGame(int difficulty)
    {
        spawnRate = 1.2f - difficulty * 0.2f;
        titleScreen.SetActive(false);
        StartCoroutine(SpawnTarget());
    }
    public void RestartGame()
    {
        InitiaizingGame();
        titleScreen.SetActive(true);

    }
    public void UpdateScore(int uScore)
    {
        if(IsGameActive)
        {
            score += uScore;
            textScore.text = "Score: " + score;
        }
    }

    public void GameOver()
    {
        IsGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    IEnumerator SpawnTarget(){
        while(IsGameActive){
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,targets.Count);
            Instantiate(targets[index]);
        }

    }

}
