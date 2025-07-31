using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject GoutteSpawner;
    private static bool restarted = false;                      //voir si on a rejouer ou non pour afficher ou non le bouton start
    List<GameObject> UiList = new List<GameObject>();
    public GameObject StartButton;
    public GameObject StartScreen;                              //le premier ecran avec les ui de start
    public GameObject RestartScreen;                            //le deuxieme ecran avec les ui de restart
    public GameObject IngameScreen;
    public GameObject PauseScreen;
    public GameObject ShopScreen;
    public GameObject DarkBg;


    //MenuGameObject pour les annimation
    public GameObject StartMenu;
    public GameObject RestartMenu;
    public GameObject IngameMenu;
    public GameObject PauseMenu;
    public GameObject ShopMenu;



    //fixer le menu restart (animer le restart screen une fois et pas plusieurs fois psk update se repete bcp)
    bool RsActive;
    // Start is called before the first frame update
    void Start()
    {
        RsActive = false;

        Time.timeScale = 1;
        SpawnerPluie.gameStarted = false;

        UiList.Add(StartScreen);
        UiList.Add(RestartScreen);
        UiList.Add(IngameScreen);
        UiList.Add(PauseScreen);
        UiList.Add(ShopScreen);
        UiList.Add(DarkBg);

        HideScreens();

        /*foreach (GameObject element in GameObject.FindGameObjectsWithTag("UI"))
        {
            UiList.Add(element);
        }*/


        //if we restarted the game (loading the scene back)
        if (!restarted)
        {
            StartScreen.SetActive(true);
            showStartScreen();
        }
        else
        {
            IngameScreen.SetActive(true);
            showIngameScreen();
            SpawnerPluie.gameStarted = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (sol.vie <= 0)
        {
            HideScreens();
            RestartScreen.SetActive(true);
            showRestartScreen();
        }
    }

    //lance le jeu si cliquer sur start (pas utilisé ici mais dans unity)
    public void start()
    {
        Time.timeScale = 1;
        HideScreens();
        IngameScreen.SetActive(true);
        showIngameScreen();
        SpawnerPluie.gameStarted = true;
    }


    //hide all ui screens
    void HideScreens()
    {
        for (int i = 0; i < UiList.Count; i++)
        {
            UiList[i].SetActive(false);
        }
    }

    public void Restart()  //recharge la scene quand cliquer sur restart
    {
        sol.vie = sol.resetVie;
        restarted = true;
        SceneManager.LoadScene(0);
    }

    public void Pause()     //Si on pause au milieu du jeu
    {
        Time.timeScale = 0;
        HideScreens();
        IngameScreen.SetActive(true);
        DarkBg.SetActive(true);
        PauseScreen.SetActive(true);
        
        showPauseScreen();
    }

    public void Resume()
    {
        removePauseScreen();
        IngameScreen.SetActive(true);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        sol.vie = sol.resetVie;
        restarted = false;
        SceneManager.LoadScene(0);
    }

    public void Store()
    {
        removeStartScreen();
        showShopScreen();
    }

    public void exitFromStore()
    {
        removeShopScreen();
        showStartScreen();
    }


    /// <summary>
    /// ANIMATIONS
    /// </summary>


    //startScreen
    void showStartScreen()
    {
        StartScreen.SetActive(true);
        StartMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -(StartMenu.GetComponent<RectTransform>().rect.height));  //on obtient la hauteur du go et on la met dans la position -hauteur pour etre parfaitement au dessous de l'ecran
        LeanTween.moveY(StartMenu.GetComponent<RectTransform>(), -667, 1f).setDelay(1f).setEaseOutExpo();
    }
    void removeStartScreen()
    {
        //TF.localPosition = new Vector2(0, -Screen.height);
        LeanTween.moveY(StartMenu.GetComponent<RectTransform>(), -(StartMenu.GetComponent<RectTransform>().rect.height), 0.5f).setEaseOutExpo().setOnComplete(startScreenNoActive);
    }


    //shopScreen
    void showShopScreen()
    {
        ShopScreen.SetActive(true);
        ShopMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        LeanTween.moveY(ShopMenu.GetComponent<RectTransform>(), 1209, 2f).setEaseOutExpo().setDelay(0.5f);
    }
    void removeShopScreen()
    {
        LeanTween.cancelAll();
        LeanTween.moveY(ShopMenu.GetComponent<RectTransform>(),0, 1f).setEaseOutExpo().setOnComplete(shopScreenNoActive);
   
    }

    //inGameScreen
    void showIngameScreen()
    {
        IngameMenu.GetComponent<RectTransform>().localPosition = new Vector2(0, Screen.height * 2);
        LeanTween.moveY(IngameMenu.GetComponent<RectTransform>(), 368, 1.5f).setEaseOutExpo();
    }
    void removeIngameScreen()
    {
        LeanTween.moveY(IngameMenu.GetComponent<RectTransform>(), Screen.height * 2, 1.5f).setEaseOutExpo().setOnComplete(ingameScreenNoActive);
        //showStartScreen();
    }

    //pauseScreen
    void showPauseScreen()
    {
        PauseMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);

        LeanTween.alpha(DarkBg.GetComponent<RectTransform>(), 0.4f , 0.5f).setIgnoreTimeScale(true);
        LeanTween.moveX(PauseMenu.GetComponent<RectTransform>(), 750, 1.5f).setEaseOutExpo().setIgnoreTimeScale(true);
    }
    void removePauseScreen()
    {
        LeanTween.alpha(DarkBg.GetComponent<RectTransform>(), 0, 0.5f);
        LeanTween.moveX(PauseMenu.GetComponent<RectTransform>(), 0, 1.5f).setEaseOutExpo().setIgnoreTimeScale(true).setOnComplete(pauseScreenNoActive);
    }

    //restartScreen
    void showRestartScreen()
    {
        if (!LeanTween.isTweening(RestartMenu)  && RsActive == false)
        {
            RestartMenu.GetComponent<Transform>().localPosition = new Vector2(0, -Screen.height * 2);
            LeanTween.moveY(RestartMenu.GetComponent<RectTransform>(), 0, 1.5f).setEaseOutExpo();
            Debug.Log("restart screen moved");
            Debug.Log(-Screen.height * 2);
            RsActive = true;
        }
    }
    void removeRestartScreen()
    {
        LeanTween.moveY(RestartMenu.GetComponent<RectTransform>(), -Screen.height * 2, 1.5f).setEaseOutExpo().setOnComplete(restartScreenNoActive);
    }




    //Leantween function set activ ----> on ne peut pas directement set active dans set on complete() alors on crée des function specifique pour ca 
    //start
    void startScreenActive()
    {
        StartScreen.SetActive(true);
    }
    void startScreenNoActive()
    {
        StartScreen.SetActive(false);
    }

    //shop
    void shopScreenActive()
    {
        ShopScreen.SetActive(true);
    }
    void shopScreenNoActive()
    {
        ShopScreen.SetActive(false);
    }

    //pause
    void pauseScreenActive()
    {
        PauseScreen.SetActive(true);
    }
    void pauseScreenNoActive()
    {
        PauseScreen.SetActive(false);
    }

    //ingame
    void ingameScreenActive()
    {
        IngameScreen.SetActive(true);
    }
    void ingameScreenNoActive()
    {
        IngameScreen.SetActive(false);
    }

    //restart 
    void restartScreenActive()
    {
        RestartScreen.SetActive(true);
    }
    void restartScreenNoActive()
    {
        RestartScreen.SetActive(false);
    }


}
