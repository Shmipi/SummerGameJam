using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpImage : MonoBehaviour
{

    public UnityEngine.UI.Image powerUpImage;
    public Sprite mushroomSpite;
    public Sprite shellSprite;

    // Start is called before the first frame update
    void Start()
    {
        powerUpImage.sprite = null;
        powerUpImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomPowerUp() {
        int powerNum = Random.Range(1, 3);
        powerUpImage.enabled = true;

        if (powerNum == 1) {
            powerUpImage.sprite = mushroomSpite;
        }

        else if (powerNum == 2) {
            powerUpImage.sprite = shellSprite;
        }
    }
}
