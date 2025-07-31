using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class scoreManager : MonoBehaviour
{
    public TextMeshProUGUI score_restart;
    public TextMeshProUGUI score;
    //public Text score_restart;              //le score dans le ui restart
    public TextMeshProUGUI HS;
    public static int waterHitLava = 0;
    public static int playerHitWater = 0;
    public int highScore = 0;
    string HsString = "HighScore\n";
    void Awake()
    {
    }
    void Start()
    {
        PlayerData data = saveSytem.LoadScore();
        highScore = data.highscore;
        waterHitLava = 0;
        playerHitWater = 0;
    }

    void Update()
    {
        HS.text = (HsString + highScore).ToString();
        score.text = playerHitWater.ToString();
        score_restart.text = playerHitWater.ToString();
        UpdateHighScore();
    }
    
    void UpdateHighScore()
    {
        if (playerHitWater > highScore)
        {
            highScore = playerHitWater;
            saveSytem.SaveScore(this);
            HS.text = (HsString + highScore).ToString();
        }
    }


}
