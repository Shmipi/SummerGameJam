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

    public GameObject playerCharacter;
    public Material[] charactersMaterial;

    bool aiGame = false;
    public TextMeshProUGUI playerTextUGUI;
    public Button marioButton;
    public Button luigiButton;
    public Button playerTextG;
    public Button characterDone;
    public Material standardMaterial;
    public static Material[] playerChoseMaterial = new Material[2]; // listan som h�ller koll p� vilka material spelarna har valt
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

        aIButton.onClick.AddListener(delegate { aiOrNot(true); });
        multiPlayerButton.onClick.AddListener(delegate { aiOrNot(false); });

        marioButton.onClick.AddListener(delegate { chooseCharacter("Mario"); });
        luigiButton.onClick.AddListener(delegate { chooseCharacter("Luigi"); });
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
        Debug.Log(ai);
        playerScreen.SetActive(false);
        charackterScreen.SetActive(true);
        aiGame = ai; //om vi ska ha Ai i spelet eller inte. om inte �r det fler spelare

        if(ai == false)
        {
            playerTextUGUI.text = "Player 1";
        }
    }

    void chooseCharacter(string name)
    {
        Debug.Log("kommer till metod");
        for(int i = 0; charactersMaterial.Length > 0; i++)
        {
            Debug.Log(name + " material: " + charactersMaterial[i].name);
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
        Debug.Log(material);

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
            }
            return;
        }
        StartCoroutine(fadeCharacterScreen(true));
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

   


    void endGame()
    {
        Application.Quit();
    }

    private IEnumerator fadeCharacterScreen(bool goToNextLevel)
    {
        charackterScreen.SetActive(false);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        if (goToNextLevel)
        {
            yield break;
        }
        blackScreen.SetActive(false);
        charackterScreen.SetActive(true);
        
        yield break;

    }

}
