using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    public int lastCheckPoint;
   

    private void Start() {
        CheckPointHandler handler = this.GetComponentInParent<CheckPointHandler>();
        lastCheckPoint = handler.getCheckPointAmount() -1;
        
    }

    private void OnTriggerEnter(Collider collider) {
        
        if (collider.CompareTag("Player")) {
            // Debug.Log("colided med player");
            PlayerCheckpoint player = collider.GetComponent<PlayerCheckpoint>();
            if (player.currentCheckPoint == lastCheckPoint) {
                player.currentCheckPoint = 0;
                player.currentLap += 1;
                // Debug.Log("lapp har g�tt up");
            }
        }
    }
}
