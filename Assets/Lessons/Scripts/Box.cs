using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		GetComponent<AudioSource>().Play();
	}

	private void OnCollisionExit(Collision collision)
	{
		
	}
}
