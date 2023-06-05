using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpBox : MonoBehaviour
{

    [SerializeField] private PowerUpImage powerImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collidedBox) {
        if (collidedBox.transform.CompareTag("PickUpBox")) {
            Debug.Log("Power up!");     // Remove
            collidedBox.gameObject.GetComponent<Renderer>().enabled = false;
            collidedBox.GetComponent <ParticleSystem>().Play ();
            ParticleSystem.EmissionModule em = collidedBox.GetComponent<ParticleSystem>().emission;
            powerImage.RandomPowerUp();
            em.enabled = true;
            Destroy(collidedBox.gameObject, 1.0F);
        }
    }
}
