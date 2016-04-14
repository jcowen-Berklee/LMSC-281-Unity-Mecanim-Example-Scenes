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

	public static AudioClip RandomFootSteps() {
		int ran = UnityEngine.Random.Range (0, footSteps.Length);

		return footSteps [ran];

	}
}
