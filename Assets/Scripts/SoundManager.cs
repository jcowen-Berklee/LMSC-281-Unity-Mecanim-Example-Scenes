using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {


    static public AudioSource SoundSource;

    // Use this for initialization
    void Start () {

    }

    static public void OneShot()
    {
        GetComponent<AudioSource>().Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
