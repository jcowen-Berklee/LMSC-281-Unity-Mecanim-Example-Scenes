using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SceneManager.LoadScene ("Follow Example");
	}
}
