using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    static public AudioClip[] Clips = new AudioClip[3];
    static public AudioSource soundSource;

    // Use this for initialization
    void Start () {
        Clips[0].name = "BearFall";
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
