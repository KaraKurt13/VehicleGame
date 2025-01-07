using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public interface IResourcesLoaderService : IService
    {
    }

    public class ResourcesLoaderService : MonoBehaviour, IResourcesLoaderService
    {
        public GameObject EnemyPrefab;
    }
}