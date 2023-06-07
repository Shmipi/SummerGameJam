using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{

    public int currentCheckPoint = 0;
    public int currentLap = 0;
    public int maxLap = 3;


    private void Update() {
        if (currentLap >= maxLap) {
            winCondition();
        }

    }

    private void winCondition() {
        Debug.Log("You win");
    }

}
