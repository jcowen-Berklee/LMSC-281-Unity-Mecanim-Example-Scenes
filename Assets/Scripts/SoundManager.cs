using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

														//with use of unity rogue-like SoundManager help
	public AudioSource efxSource;
	public AudioSource musicSource;
	public AudioSource ambientSource;
	public static SoundManager instance = null;
	public AudioSource[] sfxSoundSource;

	private int instanceCounter = 0;
	int sfxSourceLength = 0;

	bool needsCounter = false;							//increment if needed, won't if not.

	static public AudioClip[] Clips;
	static public AudioSource soundSource;

	// Use this for initialization
	public void Start () {
		//Clips[0] = ;   - tried to find a way to load the clips here but was unsuccessful
		//soundSource = GetComponent<AudioSource>();
		int sfxSourceLength = sfxSoundSource.Length;
		Debug.Log(sfxSourceLength);
		if (sfxSourceLength != 0)
			needsCounter = false;
		Debug.Log(needsCounter);
		
	}


	void Awake ()
	{
		if (instance == null)
			instance = this;
//		else if (instance != this)
//			Destroy(gameObject);
		DontDestroyOnLoad (gameObject);

	}


	public void PlaySingle (AudioClip clip)
	{
		if (instanceCounter == sfxSourceLength)
			instanceCounter = sfxSourceLength - sfxSourceLength;
		AudioSource sfx = sfxSoundSource[instanceCounter].GetComponentInChildren<AudioSource>();
		sfx.clip = clip;
		sfx.Play();
		if(needsCounter == true)
			instanceCounter++;


	}


	public void RandomizeSfx (params AudioClip[] clips)
	{
		if (instanceCounter + 1 == sfxSourceLength)
			instanceCounter = sfxSourceLength - sfxSourceLength;
		AudioSource sfx = sfxSoundSource[2].GetComponentInChildren<AudioSource>();
		int randomIndex = Random.Range(0, clips.Length);
		sfx.clip = clips[randomIndex];
		sfx.Play();

		if (needsCounter == true)
			instanceCounter++;
//		Debug.Log(instanceCounter);
	}

    public void OneShot(int i)
    {
    	soundSource.PlayOneShot(Clips[i]);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
