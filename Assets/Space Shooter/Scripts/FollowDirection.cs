using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDirection : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private string targetTag;
	private Transform target;

	void Update()
	{
		if(target == null)
		{
			target = GameObject.FindGameObjectWithTag(targetTag)?.transform;
		}
		else
		{
			Vector3 dir = (target.position - transform.position).normalized;
			transform.rotation = Quaternion.LookRotation(dir);
			transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
		}
	}
}
