using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEngineLoop : MonoBehaviour
{

    private AudioSource motorAudio;
    [SerializeField] private AudioClip engine;
    private float pVel;

    // Start is called before the first frame update
    void Start()
    {
        motorAudio = gameObject.GetComponent<AudioSource>();
        motorAudio.loop = true;
        motorAudio.clip = engine;
    }

    // Update is called once per frame
    void Update()
    {
		motorAudio.pitch = pVel/100;

		if (pVel < 0.3f) {
			motorAudio.Pause();
		}
		else {
			if (!motorAudio.isPlaying) {
				motorAudio.Play();
			}
		}
    }

    private void FixedUpdate() {
        pVel = GetComponent<Rigidbody>().velocity.magnitude;
    }
}
