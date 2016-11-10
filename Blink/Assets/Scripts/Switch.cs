using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	bool pressed = false;

	public AudioSource source;

	public AudioClip switchSound;

	private Animator anim; // animation object

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		source = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void buttonPress()
	{
		if (pressed == false) 
		{
			source.clip = switchSound;
			source.Play ();
			anim.SetBool ("flipped", true);
			pressed = true;

		}
	}

	public bool isPressed()
	{
		return pressed;
	}
}
