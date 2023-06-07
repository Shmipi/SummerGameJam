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

    private void Start()
    {
        playerController = gameObject.GetComponentInChildren<PlayerController>();
        lappText.text = "Lap: " + currentLap + " / " + maxLap;
    }


    private void Update() {

        if (currentLap >= maxLap) {
            winCondition();
        }
        lappText.text = "Lap: " + currentLap + " / " + maxLap;


    }

    private void winCondition() {
        Debug.Log("You win");

        if (playerController.secondPlayer == false)
        {
            winnigText.text = winnigText.text + " Player 1";
            GameObject pc = GameObject.Find("PlayerCanvas");
            TextMeshProUGUI wi = Instantiate(winnigText, pc.transform);
            wi.gameObject.SetActive(true);

        }
        else
        {
            winnigText.text = winnigText.text + " Player 2";
            GameObject pc = GameObject.Find("PlayerCanvas Variant");
            TextMeshProUGUI wi = Instantiate(winnigText, pc.transform);
            wi.gameObject.SetActive(true);
           
        }


    }

}
