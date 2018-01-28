using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

	private Rigidbody2D rb;
	private bool shaken = false;

	public float countTo = 2.0f;
	private float counter = 0.0f;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {

			shaken = true;
			//rb.gravityScale = 3.0f;
		}else if(coll.gameObject.tag == "Bound"){
			Destroy (this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

		if(shaken){
			counter += Time.deltaTime;
			if(counter > countTo){
				rb.bodyType = RigidbodyType2D.Dynamic;
				rb.gravityScale = 3.0f;
			}
		}

	}
}
