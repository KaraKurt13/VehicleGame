using Assets.Scripts.Infrastructure;
using Assets.Scripts.Objects.Player;
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
        private LevelData _levelData;

        [SerializeField]
        private Transform _generationStartPoint, _groundTilesContainer, _enemiesContainer;

        [SerializeField]
        private GameObject _terrainTilePrefab, _endingTilePrefab, _enemyPrefab;

        public void Init(LevelData levelData, PlayerStats playerStats)
        {
            _levelData = levelData;
            _playerStats = playerStats;
        }

        public void GenerateLevel()
        {
            GenerateTerrain();
            GenerateEnemies();
        }

        private PlayerStats _playerStats;

        private void GenerateTerrain()
        {
            var tilesCount = _levelData.Length;
            var generationStep = _terrainTilePrefab.GetComponent<MeshFilter>().sharedMesh.bounds.size.y * _terrainTilePrefab.transform.localScale.y;
            var generationPoint = _generationStartPoint.position;
            for (int i = 0; i < tilesCount - 1; i++)
            {
                generationPoint.z += generationStep;
                var prefab = Instantiate(_terrainTilePrefab, generationPoint, _terrainTilePrefab.transform.rotation, _groundTilesContainer);
            }

            var levelEndingTilePrefab = _terrainTilePrefab;
            generationPoint.z += generationStep;
            Instantiate(_endingTilePrefab, generationPoint, _endingTilePrefab.transform.rotation, _groundTilesContainer);

            _playerStats.EndingPoint = generationPoint;
            _playerStats.TotalLevelDistance = _playerStats.EndingPoint.z - _playerStats.StartPoint.z;
        }

        private void GenerateEnemies()
        {
            
        }
    }
}