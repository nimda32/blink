using UnityEngine;
using System.Collections;

public class TimedJumpTrap : MonoBehaviour {

	public GameObject wall;

	void Start () {
		StartCoroutine (toggleDeathWall());
	}
		
	bool isWallActive = false;

	IEnumerator toggleDeathWall() {
		//insures each trap starts at different times
		int wait_time = Random.Range (0, 3);
		yield return new WaitForSeconds (wait_time);

		//toggle the wall of death
		for(;;) {

			wall.SetActive( isWallActive );
			isWallActive = !isWallActive;
			//Debug.Log ("death is" + isWallActive);
			yield return new WaitForSeconds(1f);

		}
	}
}
