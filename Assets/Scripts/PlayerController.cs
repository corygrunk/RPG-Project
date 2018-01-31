using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	Camera cam;
	PlayerMotor motor;

	public Interactable focus;

	public LayerMask movementMask;

	void Start () {
		cam = Camera.main;
		motor = GetComponent<PlayerMotor>();
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, movementMask)) {
				// Move player to what we hit
				motor.MoveToPoint(hit.point);

				// Stop focusing any objects
				RemoveFocus();
			}
		}

		if (Input.GetMouseButtonDown(1)) {
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100)) {
				Interactable interactable = hit.collider.GetComponent<Interactable>();
				// Check if we hit an interactable, if yes set focus
				if (interactable != null) {
					SetFocus(interactable);
				}
			}
		}
	}

	void SetFocus (Interactable newFocus) {
		if (newFocus != focus) {
			if (focus != null) {
				focus.OnDefocused();
			}
			focus = newFocus;
			motor.FollowTarget(newFocus);
		}
		newFocus.OnFocused(transform);
	}

	void RemoveFocus () {
		if (focus != null) {
			focus.OnDefocused();
		}
		focus = null;
		motor.StopFollowingTarget();
	}

}
