using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpImage : MonoBehaviour
{
    private UnityEngine.UI.Image powerUpImage;
    public Sprite mushroomSprite;
    public Sprite shellSprite;

    // Start is called before the first frame update
    void Start()
    {
        powerUpImage = gameObject.GetComponent<UnityEngine.UI.Image>();
        powerUpImage.sprite = null;
        powerUpImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPowerImage(int x) {
        powerUpImage.enabled = true;

        if (x == 1) {
            powerUpImage.sprite = mushroomSprite;
        }

        else if (x == 2) {
            powerUpImage.sprite = shellSprite;
        }

        else if (x == 0) {
            powerUpImage.sprite = null;
            powerUpImage.enabled = false;
        }
    }
}
