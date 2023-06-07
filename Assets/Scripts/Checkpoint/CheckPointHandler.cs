using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointHandler : MonoBehaviour
{

    public List<GameObject> checkPoints = new List<GameObject>();

    private GameObject checkPointGameObjects;

    private void Awake() {
        // checkPointGameObjects = GameObject.Find("CheckpointList");
        Transform[] ts = this.GetComponentsInChildren<Transform>();
        if (ts == null) {
            Debug.LogError("No checkpoints found");
        }

        foreach (Transform t in ts) {
            if (t != null && t.gameObject != null) {
                checkPoints.Add(t.gameObject);
            }
        }

        checkPoints.Remove(checkPoints[0]);
        getCheckPointAmount();


    }

    public int getCheckPointAmount() {
        int x = checkPoints.Count;
        return x;
    }
}
