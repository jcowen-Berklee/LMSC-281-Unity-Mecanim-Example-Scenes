using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioClip[] footSteps;

	//perrin-----create 3 public/static AudioClip arrays with self documenting names
	public static AudioClip[] bearDying;
	public static AudioClip[] bazookaShot;
	public static AudioClip[] bearBreathing;




	// Use this for initialization
	void Start () {
		footSteps = new AudioClip[] {
			Resources.Load<AudioClip>("Audio/SFX/steps1"),
			Resources.Load<AudioClip>("Audio/SFX/steps2"),
			Resources.Load<AudioClip>("Audio/SFX/steps3")
		};


		//perrin---assign the bearDying AudioClip to a new AudioClip[] array with the following contents...
		bearDying = new AudioClip[] {

			//perrin----load the following sample of a bazooka sound (youtube pull) from the Resources/Audio/SFX directory
			Resources.Load<AudioClip>("Audio/SFX/BigGrunt"),
			Resources.Load<AudioClip>("Audio/SFX/SmallGrunt")

		};


		//perrin----load the following sample of a bazooka sound (youtube pull) from the Resources/Audio/SFX directory

		bazookaShot = new AudioClip[] {

			Resources.Load<AudioClip>("Audio/SFX/bazooka")

		};

		//perrin----load the following samples of a bear breathing and a more casual grunt (youtube pull) from the Resources/Audio/SFX directory
		bearBreathing = new AudioClip[] {

			Resources.Load<AudioClip>("Audio/SFX/BearBreathing1"),
			Resources.Load<AudioClip>("Audio/SFX/SmallGrunt"),
			Resources.Load<AudioClip>("Audio/SFX/BearBreathing2")



		};


	

	}

	//Plays a random sound from an AudioClip array
	public static AudioClip RandomSound(AudioClip[] audioArray) {
		int ran = UnityEngine.Random.Range (0, audioArray.Length);

		return audioArray [ran];

	}
}
