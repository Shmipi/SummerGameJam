using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
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

    public GameObject playerCharacter;
    public Material[] charactersMaterial;


    bool aiGame = false;

    public Button marioButton;
    public Button luigiButton;
    public GameObject playerTextG;
    TextMeshPro playerText;
    public Button characterDone;

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

        aIButton.onClick.AddListener(delegate { aiOrNot(true); });
        multiPlayerButton.onClick.AddListener(delegate { aiOrNot(false); });

        marioButton.onClick.AddListener(delegate { chooseCharacter("Mario"); });
        luigiButton.onClick.AddListener(delegate { chooseCharacter("Luigi"); });
        playerText = playerTextG.GetComponent<TextMeshPro>();
        //playerText.text = "Player";

        characterDone.onClick.AddListener(delegate { moveOnToTheGame();  });

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
        playerScreen.SetActive(false);
        charackterScreen.SetActive(true);
        aiGame = ai; //om vi ska ha Ai i spelet eller inte. om inte är det fler spelare

        if(ai)
        {
            playerText.text = "Player 1";
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
        Debug.Log("done knapp");
        if(aiGame == false)
        {
            playerText.text = "Player 2";
            //playerCharacter.GetComponent<MeshRenderer>().material = "Lambert";
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }


    void endGame()
    {
        Application.Quit();
    }


}
