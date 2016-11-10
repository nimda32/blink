using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicCamera : MonoBehaviour {

	static bool AudioBegin = false; 
	public AudioSource source;

	void Awake(){
		if (!AudioBegin) {
			source.Play ();
			DontDestroyOnLoad (this.gameObject);
			AudioBegin = true;
		}
	
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
