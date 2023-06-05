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
    TextMeshPro playerText;

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
    }


// Update is called once per frame
void Update()
    {
        
    }

    void startTheGame()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
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

        }
    }

    void chooseCharacter(string name)
    {
        for(int i = 0; charactersMaterial.Length > 0; i++)
        {
            if (charactersMaterial[i].name == name) {
                //Debug.Log(name + " material: " + charactersMaterial[i].name);
                playerCharacter.GetComponent<MeshRenderer>().material = charactersMaterial[i];
                return;
            }
        }

    }

    
   
    void endGame()
    {
        Application.Quit();
    }


}
