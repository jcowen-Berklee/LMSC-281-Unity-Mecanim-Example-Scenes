using UnityEngine;
using System.Collections;


public class audio_manager : MonoBehaviour {

	public AudioClip[] array;
	AudioSource footsteps;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void playfootstep () {
		footsteps = GetComponent<AudioSource> ();
		footsteps.PlayOneShot(array [Random.Range (0, array.Length)]);
	}
}
