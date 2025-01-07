using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public interface ILevelGeneratorService : IService 
    {
        public void GenerateLevel();
    }

    public class LevelGeneratorService : MonoBehaviour, ILevelGeneratorService
    {
        public LevelData LevelData;

        [SerializeField]
        private Transform _generationStartPoint, _groundTilesContainer;

        [SerializeField]
        private GameObject _terrainTilePrefab, _enemyPrefab;

        public void GenerateLevel()
        {
            GenerateTerrain();
            GenerateEnemies();
        }

        private readonly Quaternion _basicRotation = Quaternion.Euler(-90f, 0, 0);

        private void GenerateTerrain()
        {
            var tilesCount = LevelData.Length;
            var generationStep = _terrainTilePrefab.GetComponent<MeshFilter>().sharedMesh.bounds.size.y * _terrainTilePrefab.transform.localScale.y;
            var generationPoint = _generationStartPoint.position;
            for (int i = 0; i < tilesCount; i++)
            {
                generationPoint.z += generationStep;
                var prefab = Instantiate(_terrainTilePrefab, generationPoint, _basicRotation, _groundTilesContainer);
            }
        }

        private void GenerateEnemies()
        {
            
        }
    }
}