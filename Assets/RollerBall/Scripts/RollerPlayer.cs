using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RollerPlayer : MonoBehaviour
{
	[SerializeField] private float maxForce = 5;
	[SerializeField] private float jumpForce = 5;
	[SerializeField] private ForceMode forceMode;

	private Rigidbody rb;
	private Vector3 force = Vector3.zero;
	private bool grounded = true;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		Vector3 dir = Vector3.zero;

		dir.x = Input.GetAxis("Horizontal");
		dir.z = Input.GetAxis("Vertical");

		force = dir * maxForce;

		if(grounded && Input.GetButtonDown("Jump"))
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}

	private void FixedUpdate()
	{
		rb.AddForce(force, forceMode);
	}
}
