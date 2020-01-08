using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public Text scoreText, scrapText;
    public UnityEvent TimerComplete, NotEnoughFundsGatt, EnoughMoneyGatt, NotEnoughFundsMiss, EnoughMoneyMiss, NotEnoughFundsUpg, EnoughMoneyUpg, EnoughMoneyBar, NotEnoughFundsBar;

    public int playerScore = 30;
    public int minutes = 5;
    public int Scrap = 0;
    private bool firstGat = true, firstMiss = true, firstUpg = true, firstBar = true;
    private void Start()
    {
        ScrapUpdate();
    }
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
    public void ScrapUpdate()
    {
        scrapText.text = Scrap.ToString();
    }

    public void GattlingSpawn()
    {
        if (firstGat == true)
        {
            if (Scrap >= 20)
            {
                Scrap = Scrap - 20;
                EnoughMoneyGatt.Invoke();
                ScrapUpdate();
            }
            else
            {
                NotEnoughFundsGatt.Invoke();
            }
            firstGat = false;
        }

        else if(Scrap >= 40)
        {
            Scrap = Scrap - 40;
            EnoughMoneyGatt.Invoke();
            ScrapUpdate();
        }
        else
        {
            NotEnoughFundsGatt.Invoke();
        }
    }
    public void MissileSpawn()
    {
        if (firstMiss == true)
        {
            if (Scrap >= 30)
            {
                Scrap = Scrap - 30;
                EnoughMoneyMiss.Invoke();
                ScrapUpdate();
            }
            else
            {
                NotEnoughFundsMiss.Invoke();
            }
            firstMiss = false;
        }

        else if (Scrap >= 60)
        {
            Scrap = Scrap - 60;
            EnoughMoneyMiss.Invoke();
            ScrapUpdate();
        }
        else
        {
            NotEnoughFundsMiss.Invoke();
        }
    }

    public void UpgradeSpawn()
    {
        if (Scrap >= 100)
        {
            EnoughMoneyUpg.Invoke();
            ScrapUpdate();
        }
        else
        {
            NotEnoughFundsUpg.Invoke();
        }
    }

    public void BarricadeSpawn()
    {
        if(firstBar == true)
        {
            if (Scrap >= 10)
            {
                Scrap = Scrap - 10;
                EnoughMoneyBar.Invoke();
                ScrapUpdate();
                firstBar = false;
            }
            else
            {
                NotEnoughFundsBar.Invoke();
            }
        }
        else if (Scrap >= 20)
        {
            Scrap = Scrap - 20;
            EnoughMoneyBar.Invoke();
            ScrapUpdate();
        }
        else
        {
            NotEnoughFundsBar.Invoke();
        }
    }
}
