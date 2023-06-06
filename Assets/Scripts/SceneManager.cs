using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;


public class SceneManager : MonoBehaviour
{
    public Button startGame;
    public Button exitGame;
    public AudioClip startMusik;

    public Button aIButton;
    public Button multiPlayerButton;

    public GameObject startScreen;
    public GameObject playerScreen;
    public GameObject charackterScreen;
    public GameObject blackScreen;
    public GameObject levelScreen;

    public GameObject playerCharacter;
    public Material[] charactersMaterial;

    bool aiGame = false;
    public TextMeshProUGUI playerTextUGUI;
    public Button marioButton;
    public Button luigiButton;
    public Button Shy_guyButton;
    public Button Inkling_girlButton;
    public Button WarioButton;
    public Button WaluigiButton;
    public Button BroserButton;
    public Button ToadButton;

    public Button level1Button;
    public Button level2Button;
    public Button level3Button;



    public Button playerTextG;
    public Button characterDone;
    public Material standardMaterial;
    public static Material[] playerChoseMaterial = new Material[2]; // listan som håller koll på vilka material spelarna har valt
    int player = 0;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.clip = startMusik;
        source.Play();

        startGame.onClick.AddListener(delegate { startTheGame(); });
        exitGame.onClick.AddListener(delegate { endGame(); });

        startScreen.SetActive(true);
        playerScreen.SetActive(false);
        charackterScreen.SetActive(false);
        blackScreen.SetActive(false);
        levelScreen.SetActive(false);

        aIButton.onClick.AddListener(delegate { aiOrNot(true); });
        multiPlayerButton.onClick.AddListener(delegate { aiOrNot(false); });

        marioButton.onClick.AddListener(delegate { chooseCharacter("Mario"); });
        luigiButton.onClick.AddListener(delegate { chooseCharacter("Luigi"); });
        Shy_guyButton.onClick.AddListener(delegate { chooseCharacter("Shy_guy"); });
        Inkling_girlButton.onClick.AddListener(delegate { chooseCharacter("Inkling_Girl"); });
        WarioButton.onClick.AddListener(delegate { chooseCharacter("Wario"); });
        WaluigiButton.onClick.AddListener(delegate { chooseCharacter("Waluigi"); });
        BroserButton.onClick.AddListener(delegate { chooseCharacter("Broser"); });
        ToadButton.onClick.AddListener(delegate { chooseCharacter("Toad"); });

        level1Button.onClick.AddListener(delegate { levelNavigator(1); });
        level2Button.onClick.AddListener(delegate { levelNavigator(2); });
        level3Button.onClick.AddListener(delegate { levelNavigator(3); });


        playerTextUGUI.text = "Player";

        characterDone.onClick.AddListener(delegate { moveOnToTheGame();});
        playerCharacter.GetComponent<MeshRenderer>().material = standardMaterial;

    }


// Update is called once per frame
void Update()
    {
        
    }

    void startTheGame()
    {
        playerScreen.SetActive(true);
        startScreen.SetActive(false);
    }

    void aiOrNot(bool ai)
    {
        Debug.Log("ai = " + ai);
        playerScreen.SetActive(false);
        charackterScreen.SetActive(true);
        aiGame = ai; //om vi ska ha Ai i spelet eller inte. om inte är det fler spelare

        if(ai == false)
        {
            playerTextUGUI.text = "Player 1";
        }
    }

    void chooseCharacter(string name)
    {
        //Debug.Log("kommer till metod");
        for(int i = 0; charactersMaterial.Length > 0; i++)
        {
            //Debug.Log(name + " material: " + charactersMaterial[i].name);
            if (charactersMaterial[i].name == name) {
                
                playerCharacter.GetComponent<MeshRenderer>().material = charactersMaterial[i];
                return;
            }
        }
    }
    void moveOnToTheGame()
    {
        Material material = playerCharacter.GetComponent<MeshRenderer>().material;
        playerChoseMaterial[player] = material;

        if (aiGame == false){
            playerTextUGUI.text = "Player 2";
            playerCharacter.GetComponent<MeshRenderer>().material = standardMaterial;
            player = 1;
            aiGame = true;
            StartCoroutine(fadeCharacterScreen(false));
            string chosenCharacter = material.name;
            switch (chosenCharacter)
            {
                case "Mario (Instance)":
                    Debug.Log("Mario var vald");
                    marioButton.enabled = false;
                    break;
                case "Luigi (Instance)":
                    Debug.Log("Luigi var vald");
                    luigiButton.enabled = false;
                    break;
                case "Shy_guy (Instance)":
                    Shy_guyButton.enabled = false;
                    break;
                case "Inkling_Girl (Instance)":
                    Inkling_girlButton.enabled = false;
                    break;
                case "Wario (Instance)":
                    WarioButton.enabled = false;
                    break;
                case "Waluigi (Instance)":
                    WaluigiButton.enabled = false;
                    break;
                case "Broser (Instance)":
                    BroserButton.enabled = false;
                    break;
                case "Toad (Instance)":
                    ToadButton.enabled = false;
                    break;

            }
            return;
        }
        StartCoroutine(fadetoLevelScene());
              
    }

    void levelNavigator(int level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }


    void endGame()
    {
        Application.Quit();
    }

    private IEnumerator fadeCharacterScreen(bool goToNextLevel)
    {
        charackterScreen.SetActive(false);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        if (goToNextLevel)
        {
            yield break;
        }
        blackScreen.SetActive(false);
        charackterScreen.SetActive(true);
        
        yield break;

    }

    private IEnumerator fadetoLevelScene()
    {
        charackterScreen.SetActive(false);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        blackScreen.SetActive(false);
        levelScreen.SetActive(true);
        yield break;

    }

}
