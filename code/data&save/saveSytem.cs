using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class  saveSytem 
{
    //score save/load
    public static void SaveScore(scoreManager score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.kekw";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(score);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadScore()
    {
        string path = Application.persistentDataPath + "/score.kekw";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;

        }
        else
        {
            Debug.Log("error");
            return null;
        }
    }

    //coin save/load
    public static void SaveCoin(CoinManager coin)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/coin.kekw";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(coin);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadCoin()
    {
        string path = Application.persistentDataPath + "/coin.kekw";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;

        }
        else
        {
            Debug.Log("error");
            return null;
        }
    }

    //shop save
    public static void SaveShop(shopManager shopManag)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shop.kekw";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(shopManag);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadShop()
    {
        string path = Application.persistentDataPath + "/shop.kekw";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;

        }
        else
        {
            Debug.Log("error");
            return null;
        }
    }

}
