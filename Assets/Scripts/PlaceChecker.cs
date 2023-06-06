using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlaceChecker : MonoBehaviour
{
    List<GameObject> behindPlayer = new List<GameObject>();
    public int allPlayers = 10;
    int playerNumber;
    public TextMeshProUGUI textPlace;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        playerNumber = allPlayers - behindPlayer.Count;
        textPlace.text = playerNumber + "th";
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cart")
        {
            if(behindPlayer.Contains(other.gameObject)){
                behindPlayer.Remove(other.gameObject);

            }
            else
            {
                behindPlayer.Add(other.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }
}
