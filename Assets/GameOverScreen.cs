using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    // [SerializeField]
    public UnityEngine.UI.Text pointsText;
    public void Setup(){
        gameObject.SetActive(true);
        
        pointsText.text=ScoreCalculator.score.ToString()+" POINTS";
    }
    public void RestartBtn(){
        ScoreCalculator.score=0;
        SceneManager.LoadScene("SampleScene");
    }

}
