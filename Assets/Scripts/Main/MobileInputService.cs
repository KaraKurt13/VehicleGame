using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public interface IInputService : IService
    {
        Vector2 GetTouchDirection();

        Vector3 GetTouchPosition();

        bool IsTouch();

        bool IsTouchHeld();
    }

    public class MobileInputService : IInputService
    {
        public Vector2 GetTouchDirection()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    return touch.deltaPosition.normalized;
                }
            }

            return Vector2.zero;
        }

        public Vector3 GetTouchPosition()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                return touch.position;
            }

            return Vector3.zero;
        }

        public bool IsTouch()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                return touch.phase == TouchPhase.Began;
            }

            return false;
        }

        public bool IsTouchHeld()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                return touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved;
            }

            return false;
        }
    }
}