using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    static public AudioClip[] Clips;
    static public AudioSource soundSource;

    // Use this for initialization
    void Start () {
        //Clips[0] = ;   - tried to find a way to load the clips here but was unsuccessful
        soundSource = GetComponent<AudioSource>();
    }

    static public void OneShot(int i)
    {
        soundSource.PlayOneShot(Clips[i]);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
