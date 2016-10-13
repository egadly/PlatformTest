using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

    public Vector3 pos;
	private Vector3 checkpoint;
    public Vector3 vel;
	public Vector3 scale;
	public bool grounded;
	public float grav;
	public int health;
	public Vector3 feetCheck;
	public Vector3 feetCheckb;
	public Vector3 sCheck;
	public Vector3 sCheckb;
	public int invCounter = 0;
	public int frameCount = 0;
	public bool evenFrame = true;
	private Animator animator;
	private AudioSource[] aSources;
	private AudioSource landingSound;
	private AudioSource jumpingSound;
	private camera camera;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        pos = transform.position;
		checkpoint = pos;
        vel.y -= .01f;
		health = 3;
		grav = .25f;
		animator = gameObject.GetComponent<Animator>();
		aSources = gameObject.GetComponents<AudioSource>();
		landingSound = aSources [0];
		jumpingSound = aSources [1];
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<camera>();
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {

		rigidBody.WakeUp ();
		
		SpriteRenderer renderer = gameObject.GetComponent ("SpriteRenderer") as SpriteRenderer;
		renderer.color = new Color (255, 255, 255);
		frameCount++;
		if (evenFrame)
			evenFrame = false;
		else
			evenFrame = true;
		
		if (invCounter > 0) {
			invCounter--;
			if ( evenFrame ) renderer.color = new Color (255,0,0);
		}
		scale = transform.localScale;

		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			vel.y = 8;
			jumpingSound.Play ();
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			if (grounded) {
				vel.x += 2;
				scale.x = 100;
			} else
				vel.x += 3/0.96f - 3;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (grounded) {
				vel.x -= 2;
				scale.x = -100;
			} else
				vel.x -= 3/0.96f - 3;
		}

		if (grounded)
			vel.x *= 3f/5f;
		else
			vel.x *= .96f;

		vel.y *= 4f / 4.25f;

        pos += vel;
		transform.position = pos;

		sCheck = pos;
		sCheck.x -= 5.01f;
		sCheckb = sCheck;
		sCheckb.x -= .1f;
		RaycastHit2D  check = Physics2D.Linecast(sCheck,sCheckb);

		if (check) {
			if (check.collider.gameObject.tag == "Tile") {
				vel.x = 0;
				pos.x = check.collider.gameObject.transform.position.x + 13f;
				if (!grounded && Input.GetKeyDown (KeyCode.Space)) {
					jumpingSound.Play ();
					scale.x = 100;
					vel.y = 4f;
					vel.x = 3f;
				}
			}
		}

		sCheck = pos;
		sCheck.x += 5.01f;
		sCheckb = sCheck;
		sCheckb.x += .1f;
		check = Physics2D.Linecast(sCheck,sCheckb);

		if (check) {
			if (check.collider.gameObject.tag == "Tile") {
				vel.x = 0;
				pos.x = check.collider.gameObject.transform.position.x - 13f;
				if (!grounded && Input.GetKeyDown (KeyCode.Space)) {
					scale.x = -100;
					vel.y = 4f;
					vel.x = -3f;
					jumpingSound.Play ();
				}
			}
		}

		feetCheck = pos;
		feetCheck.y -= 8.01f;
		feetCheckb = feetCheck;
		feetCheckb.y -= .1f;
	    check = Physics2D.Linecast(feetCheck,feetCheckb);

		if (!check) {
			grounded = false;
		} else {
			if (check.collider.gameObject.tag == "Tile") {
				if (!grounded) {
					grounded = true;
					if (vel.y <= -3)
						landingSound.Play ();
				}
				vel.y = 0;
				pos.y = check.collider.gameObject.transform.position.y + 16f;
			}
		}

		if (!grounded)
			vel.y -= grav;

		feetCheck = pos;
		feetCheck.y += 8.01f;
		feetCheckb = feetCheck;
		feetCheckb.y += .1f;
		check = Physics2D.Linecast(feetCheck,feetCheckb);

		if (check) {
			if (check.collider.gameObject.tag == "Tile") {
				vel.y = 0;
				pos.y = check.collider.gameObject.transform.position.y - 16.2f;
			}
		}

		if (grounded && (vel.x > 0.5f || vel.x < -0.5f)) {
			animator.SetBool ("isRunning", true);
		} else
			animator.SetBool ("isRunning", false);

		transform.localScale = scale;
		Vector3 intPos = pos;
		if ((intPos.x -(float)((int)intPos.x)) > 0.5f)
			intPos.x += 1f;
		if ((intPos.y -(float)((int)intPos.y)) > 0.5f)
			intPos.y += 1f;
        transform.position = intPos;
	}

    void OnTriggerStay2D(Collider2D collider)
    {
		if (collider.gameObject.tag == "Hazard" && invCounter == 0) {
			health--;
			if (health == 0) {
				pos = checkpoint;
				health = 3;
				jumpingSound.Play ();
				vel = Vector3.zero;
				invCounter = 60;
			} else {
				vel.y = 4f;
				if (collider.gameObject.transform.position.x >= this.pos.x)
					vel.x = -3f;
				else
					vel.x = 3f;
				invCounter = 60;
				jumpingSound.Play ();
				camera.shakeCounter = 10;
			}
		}
    }

    
}
