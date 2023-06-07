using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public int checkPointNum;

    private void Start() {
        CheckPointHandler handler = this.GetComponentInParent<CheckPointHandler>();
        if (handler.checkPoints.Contains(gameObject)) {
            checkPointNum = handler.checkPoints.IndexOf(gameObject);
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            PlayerCheckpoint player = collider.GetComponent<PlayerCheckpoint>();
            if (player.currentCheckPoint == checkPointNum-1) {
                player.currentCheckPoint += 1;
            }
        }
    }
}
