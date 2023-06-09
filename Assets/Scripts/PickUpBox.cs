using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{

    [SerializeField] private float rotateSpeed = 5;

    [SerializeField] private Vector3 rotationDirection = new Vector3();

    private bool shouldRotate;

    public float waitAmount = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        shouldRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if (shouldRotate) {
            this.transform.Rotate(rotateSpeed * rotationDirection * Time.fixedDeltaTime);
        }
    }

    public void HidePowerBox() {
        StartCoroutine(hideThenShowBox());
    }

    IEnumerator hideThenShowBox()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        shouldRotate = false;
        GetComponent <ParticleSystem>().Play ();
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.enabled = true;
        yield return new WaitForSeconds(1.0f);
        // Destroy(gameObject, 1.0F);
        // gameObject.SetActive(false);
        yield return new WaitForSeconds(waitAmount);
        // gameObject.SetActive(true);
        gameObject.GetComponent<Renderer>().enabled = true;
        shouldRotate = true;
        GetComponent<BoxCollider>().enabled = true;
    }

}
