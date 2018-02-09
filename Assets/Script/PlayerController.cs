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
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public const int maxHealth = 150;
	public static int currentHealth = maxHealth; 





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
		anim.SetBool ("Shoot", false);
	

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

			controller.Move (new Vector3 (0.1f, 0f, 0f));

		}

		if (Input.GetAxis("Horizontal") < 0){


			controller.Move (new Vector3 (-0.1f, 0f, 0f));


		}

		if (Input.GetKeyDown (KeyCode.W)) {

			if (timer <= 0) {
				timer = 0.5f;
				anim.Play ("Shoot");
				Fuoco ();
			}



		}





	}

	void Fuoco(){

		var bullet = (GameObject)Instantiate (

			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);


	
		bullet.GetComponent<Rigidbody> ().AddRelativeForce (0f, 0f, 50f, ForceMode.Impulse);



		Destroy (bullet, 2.0f);


	}


	void OnCollisionEnter(Collision collision)
	{

		var hit = collision.gameObject;

		if(hit.CompareTag("PlayerDead1")){


			SceneManager.LoadScene("Level01");
			ScoreManager.score = 0;


		

		}

		if(hit.CompareTag("ActivateEnemy")){

			EnemyShootScript.activate = true;


		}
			


	}


public void TakeDamage(int amount) {

		currentHealth -= amount; 

		if (currentHealth <= 0) { 

			currentHealth = 0;

			Destroy (this.gameObject);

			SceneManager.LoadScene ("Level01");
			ScoreManager.score = 0;

			currentHealth = maxHealth;
		
		}
	}


}
