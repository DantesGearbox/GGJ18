using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	Rigidbody2D rb;
	public Transform playerT;

	private float minScaleX = 0.65f;
	private float maxScaleX = 0.8f;
	private float minScaleY = 0.65f;
	private float maxScaleY = 0.8f;
	private float rotationSpeed = 125.0f;

	float lifespan = 0.0f;
	float deathTimer = 4.0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Obstacle") {

			//transform.parent.position = transform.position;
			playerT.position = transform.position;

			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//How lerped will the scale be
		float xScale = Mathf.Abs (rb.velocity.x)/10;
		float yScale = Mathf.Abs (rb.velocity.y)/10;
		float xLerp = Mathf.Lerp (maxScaleX, minScaleX, yScale);
		float yLerp = Mathf.Lerp (maxScaleY, minScaleY, xScale);

		transform.localScale = new Vector2 (xLerp, yLerp);

		transform.Rotate (Vector3.forward * Time.deltaTime * rotationSpeed * rb.velocity.magnitude);

		lifespan += Time.deltaTime;
		if(lifespan > deathTimer){
			Destroy (this.gameObject);
		}
	}
}
