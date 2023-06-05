using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void startTheGame()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        playerScreen.SetActive(true);
    }
    void endGame()
    {
        Application.Quit();
    }


}
