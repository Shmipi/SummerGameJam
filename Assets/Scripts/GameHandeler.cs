using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

public class GameHandeler : MonoBehaviour
{
    static SceneManager sm;
    Material[] playersMaterial = new Material[2];

    public Transform playerPostiona;
    public Transform playerSceondPositon;
    public Transform playerCartPositon1;
    public Transform playerCartPositon2;
    public GameObject orgCart1;
    public GameObject orgCart2;


    public GameObject mario;
        public GameObject luigi;
        public GameObject wario;
        public GameObject waluigi;
        public GameObject toad;
        public GameObject browser;
        public GameObject inkling;
        public GameObject shy_guy;

    public bool twoPlayers = false;

    // Start is called before the first frame update
    void Start()
    {
       
       
        playersMaterial = SceneManager.playerChoseMaterial;

        if (twoPlayers)
        {
            GameObject firstPlayer = Instantiate(getPlayer(playersMaterial[0].name), playerPostiona);
           
            firstPlayer.transform.rotation = playerCartPositon1.rotation;
            firstPlayer.transform.position = playerCartPositon1.position;
            Destroy(orgCart1);


           
            GameObject secondPlayer = Instantiate(getPlayer(playersMaterial[1].name), playerSceondPositon);
           
            secondPlayer.transform.rotation = playerCartPositon2.rotation;
            secondPlayer.transform.position = playerCartPositon2.position;
            Destroy(orgCart2);
            

        }
        else
        {
            if (playersMaterial[0] != null)
            {
                
                GameObject firstPlayer = Instantiate(getPlayer(playersMaterial[0].name), playerPostiona);
                firstPlayer.transform.rotation = playerCartPositon1.rotation;
                firstPlayer.transform.position = playerCartPositon1.position;
                Destroy(orgCart1);
                
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject getPlayer(string materialName)
    {
        GameObject returnPrefab = null;

        switch (materialName)
        {
            case "Mario (Instance)":
                returnPrefab = mario;
                break;
            case "Luigi (Instance)":
                returnPrefab = luigi;
                break;
            case "Shy_guy (Instance)":
                returnPrefab = shy_guy; 
                break;
            case "Inkling_Girl (Instance)":
                returnPrefab = inkling;
                break;
            case "Wario (Instance)":
                returnPrefab = wario;
                break;
            case "Waluigi (Instance)":
                returnPrefab = waluigi;
                break;
            case "Broser (Instance)":
                returnPrefab = browser;
                break;
            case "Toad (Instance)":
                returnPrefab = toad;
                break;

        }
        return returnPrefab;
    }
}
