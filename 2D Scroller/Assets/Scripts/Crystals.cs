﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : MonoBehaviour 
{
	private Controls player;
	//public AudioSource bling;

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
		if (other.tag == "Player") 
		{
			Destroy (gameObject);
			//bling.Play ();
			player.crystals++;
		}

	}
}
