using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject sphere;

	private void Start()
	{
		//Destroy(gameObject, 6.0f);
	}

	private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
		{
            GameObject go = Instantiate(sphere, new Vector3(Random.Range(-5, 5), 2, Random.Range(-5, 5)), Quaternion.identity);
            Destroy(go, 1.0f);
		}
    }
}
