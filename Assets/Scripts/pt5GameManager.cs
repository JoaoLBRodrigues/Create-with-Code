using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class pt5GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    private float spawnRate = 1.0f;
    public Button restartButton;
   public GameObject titleScreen;
  
    void Start(){

     
    }
   
    IEnumerator SpawnTarget()
    {
        while(isGameActive){
        yield return new WaitForSeconds(spawnRate);
        int index=Random.Range(0,targets.Count);
        Instantiate(targets[index]);
          
        }
    }

  
    
    
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text="Score:" + score;

    }

      public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive=false;

    }
    public void RestartGame(){
     
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

      public void StartGame(int difficulty){
        isGameActive=true;
        score=0;
        spawnRate=spawnRate /difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
}
