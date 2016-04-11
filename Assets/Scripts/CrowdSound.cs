using UnityEngine;
using System.Collections;

public class CrowdSound : MonoBehaviour {

	public AudioClip[] footSteps; //make an arrayed variable (to attach more than one sound)
	private AudioSource steps;

	void Start ()
	{
		//Loading the items into the array
		footSteps =  new AudioClip[]{(AudioClip)Resources.Load("SFX/steps1.wav"),
			(AudioClip)Resources.Load("SFX/steps2.wav"), 
			(AudioClip)Resources.Load("SFX/steps3.wav")};
	}

	// Play random sound from footSetps audio Array
	void PlaySound()
	{
		steps = GetComponent<AudioSource> ();
		int ran = Random.Range (0, footSteps.Length);
		steps.clip = footSteps [ran]; 
		steps.Play ();
	}
}