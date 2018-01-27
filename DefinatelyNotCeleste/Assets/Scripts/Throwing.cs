using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour {

	private PlayerInput playerInput;
	private PlayerLocomotion playerLocomotion;

	private GameObject throwHandler;
	public GameObject ball;

	private float throwStrength = 50.0f;

	//Controls
	public PlayerLocomotion.BUTTONS throwButton = PlayerLocomotion.BUTTONS.Square;
	public KeyCode throwKey = KeyCode.X;

	// Use this for initialization
	void Start () {
		playerLocomotion = GetComponent<PlayerLocomotion> ();
		playerInput = GetComponent<PlayerInput> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (playerLocomotion.keyboardControls) {
			if (Input.GetKeyDown (throwKey)) {
				if (playerInput.WasButtonPressed (throwButton)) {
					throwHandler = Instantiate(ball, transform.position, Quaternion.Euler(0,0,0)) as GameObject;
					Rigidbody2D rb = throwHandler.GetComponent<Rigidbody2D> ();

					//throwHandler.transform.parent = this.gameObject.transform;

					throwHandler.GetComponent<Ball>().playerT = transform;

					float axisX = playerInput.getAxis (PlayerLocomotion.AXIS.StickLeftX);
					float axisY = playerInput.getAxis (PlayerLocomotion.AXIS.StickLeftY);

					rb.velocity = new Vector2(axisX * throwStrength, axisY * throwStrength);
					Debug.Log ("VelocityX: " + rb.velocity.x + ", VelocityY: " + rb.velocity.y);
				}
			}
		} else {
			if (playerInput.WasButtonPressed (throwButton)) {
				throwHandler = Instantiate(ball, transform.position, Quaternion.Euler(0,0,0)) as GameObject;
				Rigidbody2D rb = throwHandler.GetComponent<Rigidbody2D> ();

				//throwHandler.transform.parent = this.gameObject.transform;

				throwHandler.GetComponent<Ball>().playerT = transform;

				float axisX = playerInput.getAxis (PlayerLocomotion.AXIS.StickLeftX);
				float axisY = playerInput.getAxis (PlayerLocomotion.AXIS.StickLeftY);

				rb.velocity = new Vector2(axisX * throwStrength, axisY * throwStrength);
				Debug.Log ("VelocityX: " + rb.velocity.x + ", VelocityY: " + rb.velocity.y);
			}
		}
	}
}
