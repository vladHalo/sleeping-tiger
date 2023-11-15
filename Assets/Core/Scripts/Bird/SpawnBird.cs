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
        [SerializeField] private List<MoveBird> _moveBirds;

        [Inject] private GameManager _gameManager;

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (_gameManager.statusGame == StatusGame.Play)
            {
                var point = _spawnBirdPoint[Random.Range(0, _spawnBirdPoint.Count - 1)];
                MoveBird moveBird = _birdFactory.Create<MoveBird>(point.position);
                moveBird.SetPointMove(point, _gameManager.tigerStateManager.pointBirdsFinish, _gameManager);
                _moveBirds.Add(moveBird);
                yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
            }
        }

        public void RemoveBird(MoveBird moveBird)
        {
            _moveBirds.Remove(moveBird);
        }

        public MoveBird GetBird(float power)
        {
            if (_gameManager.abilityView.withoutPower)
            {
                if (_moveBirds.Count > 0) return _moveBirds[0];
                return null;
            }

            MoveBird bird = null;
            float boundary;
            float max = 0;

            switch (power)
            {
                case < .333f:
                    boundary = .333f;
                    break;
                case < .666f:
                    boundary = .666f;
                    break;
                default:
                    boundary = 1;
                    break;
            }

            foreach (var t in _moveBirds)
            {
                if (t.time < boundary && t.time > max)
                {
                    max = t.time;
                    bird = t;
                }
            }

            return bird;
        }
    }
}