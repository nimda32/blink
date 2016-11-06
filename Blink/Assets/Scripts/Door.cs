using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door : MonoBehaviour {

	bool locked = true; //self explanatory
	public List<GameObject> switches; //list of switches needed to be pressed for door to unlock

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Check if all the switches have been pressed
	public void checkSwitches()
	{
		Switch s;
		bool unlock = true;
		for (int i = 0; i < switches.Count; i++) 
		{
			//get the Switch instance of the switch object
			s = switches [i].GetComponent<Switch>(); 
			//check if that switch has been pressed
			if (s.isPressed() == false) 
			{
				unlock = false;
			}
		}
		locked = !unlock;
	}

	public bool isUnlocked()
	{
		return !locked;
	}
}
