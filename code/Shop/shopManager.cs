using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class shopManager : MonoBehaviour 
{
    [Serializable]
    public class shopChar      //class des produit dans le shop
    {
        public int id;
        public bool bought;
        public int price;
        public bool selected;

        public shopChar(int id,bool bought,int price,bool selected)
        {
            this.id = id;
            this.bought = bought;
            this.price = price;
            this.selected = selected;
        }

        public void select()
        {
            selected = true;
        }
    }

    int itemGonnaBuy = 1;                   //enregristrer le dernier item qu'on a selectionner pour acheter
    public GameObject buyButtons;
    public GameObject selectButton;
    public TextMeshProUGUI price;
    public static int charSelected = 1;

    public List<shopChar> Catalogue = new List<shopChar>();
    public List<GameObject> cases = new List<GameObject>();

    public GameObject S1;
    public GameObject S2;
    public GameObject S3;
    public GameObject S4;
    public GameObject S5;
    public GameObject S6;
    public GameObject S7;
    public GameObject S8;
    public GameObject S9;


    void Start()
    {
        
        cases.Insert(0, S1);
        cases.Insert(1, S2);
        cases.Insert(2, S3);
        cases.Insert(3, S4);
        cases.Insert(4, S5);
        cases.Insert(5, S6);
        cases.Insert(6, S7);
        cases.Insert(7, S8);
        cases.Insert(8, S9);
        

        if (!PlayerPrefs.HasKey("SAVELUST"))
        {
            shopChar Char1 = new shopChar(1, false, 1000, false);
            Catalogue.Insert(Char1.id - 1, Char1);
            shopChar Char2 = new shopChar(2, false, 2342, false);
            Catalogue.Insert(Char2.id - 1, Char2);
            shopChar Char3 = new shopChar(3, false, 900, false);
            Catalogue.Insert(Char3.id - 1, Char3);
            shopChar Char4 = new shopChar(4, false, 1999, false);
            Catalogue.Insert(Char4.id - 1, Char4);
            shopChar Char5 = new shopChar(5, false, 69, false);
            Catalogue.Insert(Char5.id - 1, Char5);
            shopChar Char6 = new shopChar(6, false, 53500, false);
            Catalogue.Insert(Char6.id - 1, Char6);
            shopChar Char7 = new shopChar(7, false, 50570, false);
            Catalogue.Insert(Char7.id - 1, Char7);
            shopChar Char8 = new shopChar(8, false, 507567, false);
            Catalogue.Insert(Char8.id - 1, Char8);
            shopChar Char9 = new shopChar(9, false, 99999, false);
            Catalogue.Insert(Char9.id - 1, Char9);
        }

        if (PlayerPrefs.HasKey("SAVELUST") && PlayerPrefs.GetInt("SAVELUST") == 1)
        {
            PlayerData data = saveSytem.LoadShop();
            Catalogue = data.CatalogueSave.ToList(); 
        }

        //voir quel est le personnage choisit depuis le début
        foreach (shopChar x in Catalogue)               
        {
            if(x.selected)
            {
                cases[x.id - 1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            }
            else
            {
                cases[x.id - 1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }

    }

    void Update()
    {
       
    }

    public void updateInfos()
    {
        foreach(shopChar x in Catalogue)
        {
            if (EventSystem.current.currentSelectedGameObject == cases[x.id - 1])  
            {
                if (!Catalogue[itemGonnaBuy-1].selected) { cases[itemGonnaBuy - 1].GetComponent<Image>().color = new Color32(255, 255, 255, 255); }
                price.text = x.price.ToString();                //show price text
                itemGonnaBuy = x.id;                            //se souvenir de l'item
                if(Catalogue[x.id - 1].bought)                  //activer les bouton achat ou selection
                {
                    buyButtons.SetActive(false);
                    selectButton.SetActive(true);
                }
                else
                {
                    buyButtons.SetActive(true);
                    selectButton.SetActive(false);
                }
                if (!x.selected) { cases[itemGonnaBuy - 1].GetComponent<Image>().color = new Color32(152, 152, 152, 255); }
            }
        }
    }

    public void buyItem()
    {
        CoinManager.coin -= Catalogue[itemGonnaBuy - 1].price;
        Catalogue[itemGonnaBuy - 1].price = 0;
        Catalogue[itemGonnaBuy - 1].bought = true;
        price.text = Catalogue[itemGonnaBuy -1].price.ToString();
        buyButtons.SetActive(false);
        selectButton.SetActive(true);
        saveSytem.SaveShop(this);
        if(!PlayerPrefs.HasKey("SAVELUST"))
        {
            PlayerPrefs.SetInt("SAVELUST", 1);
        }

    }

    public void selectChar()
    {
        foreach(shopChar x in Catalogue)
        {
            if (itemGonnaBuy == x.id )
            {
                x.selected = true;
                cases[x.id - 1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                saveSytem.SaveShop(this);
            }
            else
            {
                x.selected = false;
                cases[x.id - 1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                saveSytem.SaveShop(this);
            }
        }
    }

    

   
}
