using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxSpawner : MonoBehaviour
{
        [SerializeField] private GameObject[] spawnPrefabs;
        [SerializeField] private float minTime;
        [SerializeField] private float maxTime;

        private BoxCollider boxCollider;
        private float timer;

        void Start()
        {
                boxCollider = GetComponent<BoxCollider>();
                timer = Random.Range(minTime, maxTime);
        }

        void Update()
        {
                timer -= Time.deltaTime;

                if(timer <= 0)
		{
                        timer = Random.Range(minTime, maxTime);

                        Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Length)], GetRandomPoint(), transform.rotation);
                }
        }

        Vector3 GetRandomPoint()
	{
                return new Vector3(Random.Range(0, boxCollider.size.x), 0, Random.Range(0, boxCollider.size.y)) + boxCollider.bounds.min;
        }
}