using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public interface ICameraService : IService
    {
        public void ChangeCameraState(CameraStateEnum state, bool instantly = false);
    }

    public class CameraService : MonoBehaviour, ICameraService
    {
        private Camera _camera;

        [SerializeField]
        private Transform _sideView, _followView;

        public void Init()
        {
            _camera = Camera.main;
        }

        public void ChangeCameraState(CameraStateEnum state, bool instantly = false)
        {
            var changeTime = instantly ? 0f : 2f;
            switch (state)
            {
                case CameraStateEnum.Following:
                    StartCoroutine(MoveCamera(_sideView, _followView, changeTime));
                    break;
                case CameraStateEnum.SideView:
                    StartCoroutine(MoveCamera(_followView, _sideView, changeTime));
                    break;
            }
        }

        private IEnumerator MoveCamera(Transform start, Transform end, float duration)
        {
            var elapsedTime = 0f;
            var startPos = start.localPosition;
            var startRot = start.localRotation;

            while (elapsedTime < duration)
            {
                var progress = elapsedTime / duration;
                Camera.main.transform.localPosition = Vector3.Lerp(startPos, end.localPosition, progress);
                Camera.main.transform.localRotation = Quaternion.Slerp(startRot, end.localRotation, progress);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            Camera.main.transform.localPosition = end.localPosition;
            Camera.main.transform.localRotation = end.localRotation;
        }
    }
}