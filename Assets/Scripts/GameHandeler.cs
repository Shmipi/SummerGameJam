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
    public Transform playerCartPositon;
    public GameObject orgCart;


    public GameObject mario;
        public GameObject luigi;
        public GameObject wario;
        public GameObject waluigi;
        public GameObject toad;
        public GameObject browser;
        public GameObject inkling;
        public GameObject shy_guy;
    public Camera firtsPlayersCamera;

   
    // Start is called before the first frame update
    void Start()
    {
       
       
        playersMaterial = SceneManager.playerChoseMaterial;


        if (playersMaterial[0] != null)
        {
            GameObject firstPlayer = Instantiate(getPlayer(playersMaterial[0].name), playerPostiona);
            firstPlayer.transform.rotation = playerCartPositon.rotation;
            firstPlayer.transform.position = playerCartPositon.position;
            Destroy(orgCart);
        }
        if (playersMaterial[1] != null)
        {
            Instantiate(getPlayer(playersMaterial[1].name), playerPostiona);
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
