using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField][Range(1, 10)][Tooltip("Movement speed of the player")] private float speed;
    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        transform.position += direction * speed * Time.deltaTime;

        if(Input.GetButtonDown("Fire1"))
		{
            audioSource.Play();
            GetComponent<Renderer>().material.color = Color.magenta;
        }
    }
}
