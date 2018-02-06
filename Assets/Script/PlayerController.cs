using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	private Animator anim;
	bool isJump=false;
	public float timer = 0.5f;
	public GameObject MainCameras;
	public float speed = 2.0F;
	public float jumpSpeed = 1.0F;
	public float gravity = 5.0F;
	public float verticalVelocity;
	public float rotation = 0f;
	CharacterController controller;
	private Vector3 moveDirection;




	// Use this for initialization
	void Start () {


		moveDirection = new Vector3 (0f, verticalVelocity , speed);
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		controller = rb.GetComponent<CharacterController> ();

	}




	void FixedUpdate() {


		moveDirection = new Vector3 (0f, verticalVelocity, speed);


		anim.SetBool ("Jump", false);

		if (controller.isGrounded) {
			verticalVelocity = -gravity * Time.deltaTime;



			if (Input.GetMouseButton (0)) {

				if (isJump == false) {
					verticalVelocity = jumpSpeed;
					anim.Play("Jumping");

				}


			}
		} else {

			verticalVelocity -= gravity * Time.deltaTime;

		}


		controller.Move (moveDirection);

		timer -= Time.deltaTime;

		if (Input.GetAxis("Horizontal")> 0){

			controller.Move (new Vector3 (0.07f, 0f, 0f));

		}

		if (Input.GetAxis("Horizontal") < 0){


			controller.Move (new Vector3 (-0.07f, 0f, 0f));


		}


	}



}
