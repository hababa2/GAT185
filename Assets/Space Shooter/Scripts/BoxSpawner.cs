using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxSpawner : MonoBehaviour
{
        [SerializeField] private GameObject[] spawnPrefabs;
        [SerializeField] private float minTime;
        [SerializeField] private float maxTime;
        [SerializeField] private bool active = false;

        private BoxCollider boxCollider;
        private float timer;
        public float timeModifier = 1;

        void Start()
        {
                boxCollider = GetComponent<BoxCollider>();
                timer = Random.Range(minTime, maxTime);

                GameManager.Instance.startGameEvent += OnStartGame;
                GameManager.Instance.stopGameEvent += OnStopGame;
        }

        void Update()
        {
                if(!active) { return; }

                timer -= Time.deltaTime;

                if(timer <= 0 && timeModifier >= 0.2f)
		{
                        timer = Random.Range(minTime, maxTime) * timeModifier;

                        Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Length)], GetRandomPoint(), transform.rotation);
                }
        }

        Vector3 GetRandomPoint()
	{
                return new Vector3(Random.Range(0, boxCollider.size.x), 0, Random.Range(0, boxCollider.size.y)) + boxCollider.bounds.min;
        }

        public void OnStartGame()
	{
                active = true;
	}

        public void OnStopGame()
        {
                active = false;
        }
}