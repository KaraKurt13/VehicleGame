using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public interface IInputService : IService
    {
        Vector2 GetTouchPosition();

        bool IsTouch();
    }

    public class MobileInputService : IInputService
    {
        public Vector2 GetTouchPosition()
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

        public bool IsTouch()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                return touch.phase == TouchPhase.Began;
            }

            return false;
        }
    }
}