using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour 
{
	public Rigidbody2D rb;
	public float movespeed;
	public float jumpheight;
	public bool moveright;
	public bool moveleft;
	public bool jump;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool onGround;

	public int crystals = 0;

	private Animator anim;

	public int level = 1;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.LeftArrow))
			rb.velocity = new Vector2 (-movespeed, rb.velocity.y);
		
		if (Input.GetKey (KeyCode.RightArrow))
			rb.velocity = new Vector2 (movespeed, rb.velocity.y);

		if (Input.GetKey (KeyCode.Space) && onGround)
			rb.velocity = new Vector2 (rb.velocity.x, jumpheight);

		if (jump) 
		{
			rb.velocity = new Vector2 (rb.velocity.x, jumpheight);
			jump = false;
		}

		if (moveright)
			rb.velocity = new Vector2 (movespeed, rb.velocity.y);

		if (moveleft)
			rb.velocity = new Vector2 (-movespeed, rb.velocity.y);

		// This is for the animation of rusty looking compressed when moving
		if (rb.velocity.x != 0 && onGround)
			anim.SetBool ("Walking", true);
		else
			anim.SetBool ("Walking", false);

		// Once you gather all 8 gems, you move to level2
		// Better to use a "level manager" script but good for now. 
		if (crystals == 8 && level == 1) 
		{
			level++;
			crystals = 0;
			Application.LoadLevel ("Level1.5");
		}
		else if (crystals == 8 && level == 2)
		{
			Application.LoadLevel ("Level2");
		}
	}

	void FixedUpdate()
	{
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
}
