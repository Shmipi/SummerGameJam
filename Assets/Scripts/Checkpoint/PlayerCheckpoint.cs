using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{

    public int currentCheckPoint = 0;
    public int currentLap = 0;
    public int maxLap = 3;

    PlayerController playerController;
    public TextMeshProUGUI winnigText;
    public TextMeshProUGUI lappText;
    GameHandeler gameHandeler;

    private void Start()
    {
        playerController = gameObject.GetComponentInChildren<PlayerController>();
        lappText.text = "Lap: " + currentLap + " / " + maxLap;
    }


    bool textup = false;
    private void Update() {

        if (currentLap >= maxLap) {
            if(textup == false)
            {
                winCondition();
                textup = true;
            }
            
        }
        lappText.text = "Lap: " + currentLap + " / " + maxLap;


    }

    private void winCondition() {
        Debug.Log("You win");

        if (playerController.secondPlayer == false)
        {
            GameObject gh = GameObject.Find("GameHandeler");
            gameHandeler = gh.GetComponent<GameHandeler>();

            if(gameHandeler.twoPlayers == true)
            {
                winnigText.text = "Player 1 Wins";
            }
            else
            {
                winnigText.text = "Player Wins";

            }

            GameObject pc = GameObject.Find("PlayerCanvas");
            TextMeshProUGUI wi = Instantiate(winnigText, pc.transform);
            wi.gameObject.SetActive(true);

        }
        else
        {
            winnigText.text = "Player 2 Wins";
            GameObject pc = GameObject.Find("PlayerCanvas Variant");
            TextMeshProUGUI wi = Instantiate(winnigText, pc.transform);
            wi.gameObject.SetActive(true);
           
        }


    }

}
