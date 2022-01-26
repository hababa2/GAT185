using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour, IDestructable
{
        [SerializeField] [Range(1, 100)] [Tooltip("Movement speed of the player")] private float speed = 40;

	private void Update()
        {
                Vector3 direction = Vector3.zero;

                direction.x = Input.GetAxis("Horizontal");
                direction.z = Input.GetAxis("Vertical");

                transform.Translate(direction * speed * Time.deltaTime);

                if (Input.GetButton("Fire1"))
                {
                        GetComponent<SpaceWeapon>().Fire();
                }

                GameManager.Instance.playerHealth = GetComponent<Health>().health;
        }

        public void Destroyed()
        {
                GameManager.Instance.playerHealth = 0;
                GameManager.Instance.OnPlayerDead();
        }
}