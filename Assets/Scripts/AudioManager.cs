using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioClip[] footSteps;

	// Use this for initialization
	void Start () {
		footSteps = new AudioClip[] {
			Resources.Load<AudioClip>("Audio/SFX/steps1"),
			Resources.Load<AudioClip>("Audio/SFX/steps2"),
			Resources.Load<AudioClip>("Audio/SFX/steps3")
		};
	}

	//Plays a random sound from an AudioClip array
	public static AudioClip RandomSound(AudioClip[] audioArray) {
		int ran = UnityEngine.Random.Range (0, audioArray.Length);

		return audioArray [ran];

	}
}
