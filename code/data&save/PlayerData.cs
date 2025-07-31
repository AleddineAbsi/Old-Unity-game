using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class PlayerData {

    public int highscore;
    public int coin;
    //public int currentChar;



    [SerializeField] public List<shopManager.shopChar> CatalogueSave = new List<shopManager.shopChar>();

    public PlayerData (scoreManager score)
    {
        highscore = score.highScore;
    }

    public PlayerData (CoinManager coinManag)
    {
        coin = CoinManager.coin;
    }

    public PlayerData (shopManager shoManag)
    {
        CatalogueSave = shoManag.Catalogue.ToList();
    }
   
}
