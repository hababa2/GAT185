using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDirectionMovement : MonoBehaviour
{
        [SerializeField] private Vector3 direction;
        [SerializeField] private float speed;
        [SerializeField] private Space space = Space.Self;

        void Update()
        {
                transform.Translate(direction * speed * Time.deltaTime, space);
        }
}