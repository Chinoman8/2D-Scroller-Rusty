using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hazards : MonoBehaviour 
{
	private Controls player;
	public Transform start;
	public Transform Explode;

	private bool dead;

	// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType<Controls> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		/*
		if (other.tag == "Player") 
		{
			player.transform.position = start.position;	
			dead = true;
		}
		*/


		if (other.tag == "Player")
			StartCoroutine ("respawndelay");
	}

	public IEnumerator respawndelay()
	{
		Instantiate (Explode, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		player.GetComponent<Renderer> ().enabled = false;
		yield return new WaitForSeconds (1);
		player.transform.position = start.position;
		player.GetComponent<Renderer> ().enabled = true;
		player.enabled = true;

		dead = true;
	}

	void OnGUI()
	{
		if (dead)
			GUI.Label (new Rect (0, 3, 500, 500), "You suck!");
		//dead = false;
		//if (!dead)
		//	enabled = false;
	}
}
