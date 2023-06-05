using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpImage : MonoBehaviour
{

    public UnityEngine.UI.RawImage powerUpImage;
    public Texture mushroomSpite;
    public Texture shellSprite;

    // Start is called before the first frame update
    void Start()
    {
        powerUpImage.texture = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomPowerUp() {
        int powerNum = Random.Range(1, 3);

        if (powerNum == 1) {
            powerUpImage.texture = mushroomSpite;
        }

        else if (powerNum == 2) {
            powerUpImage.texture = shellSprite;
        }
    }
}
