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
	public float speed;
	public float jumpSpeed = 1.0F;
	public float gravity = 5.0F;
	public float verticalVelocity;
	CharacterController controller;
	private Vector3 moveDirection;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public const int maxHealth = 150;
	public static int currentHealth = maxHealth; 
	public bool primacurva;
	private bool finish;
	private bool morto;
	private float deathTimer;
	private float hitTimer;
	public static bool hitted = false;
	public static bool pause = false;
	public static bool setPalyer;
	private bool arrivo;
	public static bool menuFine =false;
	public MenuPrincipale menu;
	private AudioSource audio;
	public AudioSource death;
	public AudioSource coin;

	// Use this for initialization
	void Start () {


		moveDirection = new Vector3 (0f, verticalVelocity , speed);
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		controller = rb.GetComponent<CharacterController> ();
		primacurva = false;
		hitTimer = 1.0f;
		finish = false;
		morto = false;
		deathTimer = 3f;
		setPalyer = false;
		arrivo = false;
		menuFine = false;
		ScoreManager.score = 0;
		audio = GetComponent<AudioSource> ();

	}




	void FixedUpdate() {

		if (setPalyer) {



			if (pause == true) {


				moveDirection = new Vector3 (0f, 0f, 0f);
				controller.Move (moveDirection);
				anim.Play ("Idle");
		
		
			} else {
		
		
		
			
				hitted = anim.GetBool ("Hit");

				if (hitted == true) {
					hitTimer -= Time.deltaTime;
					moveDirection = new Vector3 (0f, 0f, 0f);

					if (hitTimer <= 0) {

						anim.SetBool ("Hit", false);
						hitted = false;
						hitTimer = 1.0f;
			
			
					}
		
		
		
				}

				if (arrivo.Equals (true)) {
		
					moveDirection = new Vector3 (0f, 0f, 0f);
		
		
				} else if (primacurva == true) {

					moveDirection = new Vector3 (speed, verticalVelocity, 0f);		
		
				} else {
					moveDirection = new Vector3 (0f, verticalVelocity, speed);
				}

				if (morto == true) {
					deathTimer -= Time.deltaTime;
					moveDirection = new Vector3 (0f, 0f, 0f);

					if (deathTimer <= 0) {
						currentHealth = maxHealth;
						Scene active = SceneManager.GetActiveScene ();
						SceneManager.LoadScene (active.name);
						ScoreManager.score = 0;
					}
				}

				anim.SetBool ("Jump", false);
				anim.SetBool ("Shoot", false);
	

				if (controller.isGrounded && finish == false) {
					verticalVelocity = -gravity * Time.deltaTime;



					if (Input.GetKey (KeyCode.Space)) {

						if (isJump == false) {
							audio.Play ();
							verticalVelocity = jumpSpeed;
							anim.Play ("Jumping");

						}


					}
				} else {

					verticalVelocity -= gravity * Time.deltaTime;

				}


				controller.Move (moveDirection);

				timer -= Time.deltaTime;
				if (finish == false) {
			
					if (Input.GetAxis ("Horizontal") > 0 && morto==false) {

						if (primacurva == true) {

							controller.Move (new Vector3 (0f, 0f, -0.1f));

						} else {

							controller.Move (new Vector3 (0.1f, 0f, 0f));
						}
					}


					if (Input.GetAxis ("Horizontal") < 0 && morto == false) {

						if (primacurva == true) {
			
							controller.Move (new Vector3 (0f, 0f, 0.1f));
						
						} else {
					
							controller.Move (new Vector3 (-0.1f, 0f, 0f));
						}

					}

					if ((Input.GetKeyDown (KeyCode.W) || Input.GetAxis ("Vertical") > 0) && morto == false && arrivo == false) {

						if (timer <= 0) {
							timer = 0.5f;
							anim.Play ("Shoot");
							Fuoco ();
						}



					}
				}



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
			
			this.TakeDamage (150);
		

		}

		if(hit.CompareTag("ActivateEnemy")){

			EnemyShootScript.activate = true;


		}

		if(hit.CompareTag("ActivateEnemy2")){

			NemicoSecondoLivello.activate = true;


		}


		if(hit.CompareTag("DeactivateEnemy")){

			EnemyShootScript.activate = false;


		}


		if(hit.CompareTag("NemicoLivello2")){


			this.TakeDamage (50);


		}

		if (hit.CompareTag ("CurvaADX")) {

	
			this.transform.Rotate (new Vector3 (0, 45, 0));
		
			this.transform.position =  new Vector3 (9.08f, -0.74f, 1003.43f);

			primacurva = true;
		
		
		
		}

		if (hit.CompareTag ("Arrivo")) {
		
			arrivo = true;
			menuFine = true;
			anim.SetBool ("Finish", true);
			Scene current = SceneManager.GetActiveScene ();
			string name = current.name.ToString ();

			if (name.Equals ("Livello1")) {

				if (ScoreManager.score >= PlayerPrefs.GetFloat("ScoreLivello1")) {


					PlayerPrefs.SetFloat ("ScoreLivello1", ScoreManager.score);
				
				}
			
			
			}

			if (name.Equals ("Livello2")) {

				if (ScoreManager.score >= PlayerPrefs.GetFloat("ScoreLivello2")) {


					PlayerPrefs.SetFloat ("ScoreLivello2", ScoreManager.score);

				}


			}

			if (name.Equals ("Level01")) {

				if (ScoreManager.score >= PlayerPrefs.GetFloat("ScoreLivello3")) {


					PlayerPrefs.SetFloat ("ScoreLivello3", ScoreManager.score);

				}


			}
		
		}

		if (hit.CompareTag ("Hitable")) {


			hitted = true;
			anim.SetBool ("Hit", true);


			if (true) {
				this.TakeDamage (50);


			}



		}




	
			


	}


public void TakeDamage(int amount) {

		currentHealth -= amount; 

		if (currentHealth <= 0) { 

			currentHealth = 0;
			death.Play ();
			anim.SetBool ("Death", true);
			anim.Play ("Death");
			finish = true;
			morto = true;



			currentHealth = maxHealth;
		
		}
	}


	public void Restore() {

		currentHealth = maxHealth; 

	}

	public void OnTriggerEnter(){
		coin.Play ();
	
	}


}
