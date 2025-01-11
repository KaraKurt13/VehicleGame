using Assets.Scripts.Infrastructure;
using Assets.Scripts.Objects.Enemies;
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

        private List<Enemy> _enemies;

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

        public void ResetLevel()
        {
            foreach (var enemy in _enemies)
            {
                enemy.ResetEnemy();
            }
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
                var point = generationPoint;
                var prefab = Instantiate(_terrainTilePrefab, point, _terrainTilePrefab.transform.rotation, _groundTilesContainer);
                _groundTileVectors.Add(point);
            }

            var levelEndingTilePrefab = _terrainTilePrefab;
            generationPoint.z += generationStep;
            Instantiate(_endingTilePrefab, generationPoint, _endingTilePrefab.transform.rotation, _groundTilesContainer);

            _playerStats.EndingPoint = generationPoint;
            _playerStats.TotalLevelDistance = _playerStats.EndingPoint.z - _playerStats.StartPoint.z;
        }

        private List<Vector3> _groundTileVectors = new();

        private const float _xSpawnOffset = 3f, _zSpawnOffset = 60f;

        private void GenerateEnemies()
        {
            var enemiesCount = _levelData.EnemiesCount;
            var tilesCount = _groundTileVectors.Count;
            var enemiesPerTile = Mathf.CeilToInt(enemiesCount / tilesCount);
            _enemies = new();
            foreach(var tileCenter in _groundTileVectors)
            {
                for (int i = 0; i < enemiesPerTile; i++)
                {
                    var offsetX = Random.Range(-_xSpawnOffset, _xSpawnOffset);
                    var offsetZ = Random.Range(-_zSpawnOffset, _zSpawnOffset);
                    var spawnPoint = new Vector3(
                        tileCenter.x +  offsetX,
                        tileCenter.y,
                        tileCenter.z + offsetZ);
                    var enemy = Instantiate(_enemyPrefab, spawnPoint, _enemyPrefab.transform.rotation, _enemiesContainer).GetComponent<Enemy>();
                    _enemies.Add(enemy);
                }
            }
        }
    }
}