using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyParticles : MonoBehaviour 
{
	private ParticleSystem thisParticleSystem;

	private bool destroy;

	// Use this for initialization
	void Start () 
	{
		thisParticleSystem = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (thisParticleSystem.isPlaying) 
			return;

		Destroy (gameObject);
		destroy = true;
		//OnGUI ();

	}

	void OnGUI()
	{
		if (destroy)
			GUI.Label (new Rect (0, 3, 500, 500), "WE FUCKING KILLED IT");
		//dead = false;
		//if (!dead)
		//	enabled = false;
	}
}
