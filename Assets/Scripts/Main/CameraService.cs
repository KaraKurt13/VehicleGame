using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public interface ICameraService : IService
    {
        public void ChangeCameraState(CameraStateEnum state);
    }

    public class CameraService : MonoBehaviour, ICameraService
    {
        private Camera _camera;
        public void Init()
        {
            _camera = Camera.main;
        }

        public void ChangeCameraState(CameraStateEnum state)
        {

        }
    }
}