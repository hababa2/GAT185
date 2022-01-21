using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
        [SerializeField] private GameObject deathPrefab;
        [SerializeField] private bool destroyOnDeath = true;

        [SerializeField] private float maxHealth = 100;

        [HideInInspector] public float health;

        void Start()
        {
                health = maxHealth;
        }

        public void Damage(float damage)
	{
                health -= damage;

                if(health <= 0)
		{
                        GameManager.Instance.Score += 100;

                        if(deathPrefab != null)
			{
                                Instantiate(deathPrefab, transform.position, transform.rotation);
			}

                        if(destroyOnDeath)
			{
                                Destroy(gameObject);
			}
		}
	}
}