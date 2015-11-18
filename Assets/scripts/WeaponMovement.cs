using UnityEngine;
using System.Collections;

public class WeaponMovement : MonoBehaviour {

	void Update () {
		Move ();
	}

	void Move() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit rayHit;

		if (Physics.Raycast (ray, out rayHit)) {
			Vector2 movement = new Vector2(transform.position.x,
			                               rayHit.point.y);

			transform.position = movement;
		}
	}
}
