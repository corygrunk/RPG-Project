﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	Camera cam;
	PlayerMotor motor;

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
			}
		}

		if (Input.GetMouseButtonDown(1)) {
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, movementMask)) {
				// Check if we hit an interactable, if yes set focus
			}
		}
	}
}
