using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
        [SerializeField] private float damage;

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.TryGetComponent(out Health health))
		{
			health.Damage(damage);
		}
	}
}