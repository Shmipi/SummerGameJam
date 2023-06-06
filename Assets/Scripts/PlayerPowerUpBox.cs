using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpBox : MonoBehaviour
{

    // [SerializeField] private PowerUpImage powerImage;

    private PowerUpImage powerImage;

    private int powerNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject pc = GameObject.Find("PlayerCanvas");
        powerImage = pc.GetComponentInChildren<PowerUpImage>();
    }

    // Update is called once per frame
    void Update()
    {
            // Here Ludvig
        if (Input.GetKey("e"))
        {
            usePower();
        }
    }

    private void OnTriggerEnter(Collider collidedBox) {
        if (collidedBox.transform.CompareTag("PickUpBox")) {
            // Debug.Log("Power up!");
            collidedBox.GetComponent<PickUpBox>().HidePowerBox();
            randomPowerUp();
        }
    }

    private void randomPowerUp() {
        if (powerNum == 0) {
            powerNum = Random.Range(1, 3);
            powerImage.setPowerImage(powerNum);
        }
    }


    private void usePower() {
        if (powerNum == 1) {
            Debug.Log("SHRROOOOM!");
        }

        else if (powerNum == 2) {
            Debug.Log("Shell.");
        }

        powerNum = 0;
        powerImage.setPowerImage(powerNum);
    }


}
