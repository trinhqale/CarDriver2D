using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.InputSystem;
using UnityEngine;

namespace Source.Scripts
{
    public class Driver : MonoBehaviour
    {
        // Start is called before the first frame update
        
        private float steerSpeed = 0.1f;
        private float steerAmount; 
        private bool steerLeft = false;
        private bool steerRight = false;
        private float moveSpeed = 0.0f;

        private float accel = 0.5f;
        private bool speedUp = false;

        void Start()
        {
            transform.Rotate(0, 0, -45);
        }

        // Update is called once per frame
        void Update()
        {
            if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
            {
                steerLeft = true;
            }
            else if (Keyboard.current.leftArrowKey.wasReleasedThisFrame)
            {
                steerLeft = false;
            }

            if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
            {
                steerRight = true;
            }
            else if(Keyboard.current.rightArrowKey.wasReleasedThisFrame)
            {
                steerRight = false;
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                speedUp = true;
            }
            else if (Keyboard.current.spaceKey.wasReleasedThisFrame)
            {
                speedUp = false;
            }

            if (speedUp)
            {
                moveSpeed += accel * Time.deltaTime;
                moveSpeed = Math.Min(moveSpeed, 1);
            }
            else
            {
                moveSpeed -= Time.deltaTime;
                moveSpeed = Math.Max(moveSpeed, 0);
            }
            transform.Translate(0, moveSpeed, 0);
            

                if (steerLeft)
            {
                steerAmount += Time.deltaTime * steerSpeed * 1000;
                transform.Rotate(0, 0, steerAmount);
            }
            else
            {
                steerAmount = 0;
            }

            if (steerRight)
            {
                steerAmount -= Time.deltaTime * steerSpeed * 1000;
                transform.Rotate(0, 0, steerAmount);
            }
            else
            {
                steerAmount = 0;
            }
            

            
        }
    }
}