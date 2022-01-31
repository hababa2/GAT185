using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCamera : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private float distance = 5.0f;
	[SerializeField] private float pitch = 45.0f;
	[SerializeField] private float sensitivity = 1.0f;

	private float yaw = 0.0f;

	void Update()
	{
		Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);
		Vector3 offset = qpitch * Vector3.back * distance;
		transform.position = target.position + offset;
	}
}
