using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public Text scoreText, scrapText;
    public UnityEvent TimerComplete;

    public int playerScore = 30;
    public int minutes = 5;
    public int Scrap = 0;
    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        AddScore.OnSendScore += UpdateScore;
        AddScrap.OnSendScrap += UpdateScrap;
    }

    
    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        AddScore.OnSendScore -= UpdateScore;
        AddScrap.OnSendScrap -= UpdateScrap;
    }

    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }

    private void UpdateScore(int theScore)
    {
        playerScore +=  theScore;

        if(playerScore == 0f && minutes == 0f)
        {
            Time.timeScale = 0f;
            TimerComplete.Invoke();
        }
        else if (playerScore == -1f)
        {
            minutes = minutes - 1;
            playerScore = 59;
        }
        scoreText.text = minutes.ToString() + ":" + playerScore.ToString("00");
    }

    private void UpdateScrap(int theScrap)
    {
        Scrap = Scrap + theScrap;
        scrapText.text = Scrap.ToString();
    }
}
