﻿//The actual movement of the player within the scene
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace Server
{
    public class PlayerMovement : MonoBehaviour
    {
        private float moveSpeed = 2.0f;
        Rigidbody2D rb2d;

        // Use this for initialization
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        public void MoveInDirection(Vector2 direction)
        {
            Vector2 velocity = direction * moveSpeed * Time.fixedDeltaTime;
            transform.Translate(velocity);
        }

        public float GetMoveSpeed()
        {
            return moveSpeed;
        }

        public void SetMoveSpeed(float newSpeed)
        {
            moveSpeed = newSpeed;
        }
    }
}

