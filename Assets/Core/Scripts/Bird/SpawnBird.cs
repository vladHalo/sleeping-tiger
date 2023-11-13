using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Bird
{
    public class SpawnBird : MonoBehaviour
    {
        [SerializeField] private Factory _birdFactory;
        [SerializeField] private List<Transform> _spawnBirdPoint;
        [SerializeField] private float _minDelay, _maxDelay;

        [Inject] private GameManager _gameManager;

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                MoveBird moveBird = _birdFactory.Create<MoveBird>(new Vector3());
                moveBird.SetPointMove(_spawnBirdPoint[Random.Range(0, _spawnBirdPoint.Count - 1)],
                    _gameManager.tigerStateManager.pointBirdsFinish, _gameManager);
                _gameManager.moveBirds.Add(moveBird);
                yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
            }
        }
    }
}