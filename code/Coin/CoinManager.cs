using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static int coin = 0;
    public TextMeshProUGUI coinCounter1;
    public TextMeshProUGUI coinCounter2;
    void Start()
    {
        PlayerData data = saveSytem.LoadCoin();
        coin = data.coin;
    }

    void Update()
    {
        if (coinCounter1.text != coin.ToString() || coinCounter2.text != coin.ToString())
        {
            coinCounter1.text = coin.ToString();
            coinCounter2.text = coin.ToString();
            saveSytem.SaveCoin(this);
        }
    }

    public void addCoin() //test function
    {
        coin+=999990;
    }
    
    public void removeCoin() //test function
    {
        coin -= 9995990;
    }
}
