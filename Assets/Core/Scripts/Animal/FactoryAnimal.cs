using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Bird
{
    public class FactoryAnimal : MonoBehaviour
    {
        public bool withoutPower;
        
        [SerializeField] private Factory _animalFactory;
        [SerializeField] private List<Transform> _spawnAnimalPoint;
        [SerializeField] private float _minDelay, _maxDelay;
        [SerializeField] private List<MoveAnimal> _moveAnimals;

        [Inject] private GameManager _gameManager;

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (_gameManager.statusGame == StatusGame.Play)
                {
                    var point = _spawnAnimalPoint[Random.Range(0, _spawnAnimalPoint.Count - 1)];
                    MoveAnimal moveAnimal = _animalFactory.Create<MoveAnimal>(point.position);
                    moveAnimal.SetPointMove(point, _gameManager.tigerStateManager.pointBirdsFinish, _gameManager);
                    _moveAnimals.Add(moveAnimal);
                }
                yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
            }
        }

        public void RemoveAllAnimal()
        {
            _moveAnimals.ForEach(x =>
            {
                LeanPool.Despawn(x.gameObject);
                _gameManager.animalCountView.AddCount();
            });
            _moveAnimals.Clear();
        }

        public void RemoveAnimal(MoveAnimal moveAnimal)
        {
            _moveAnimals.Remove(moveAnimal);
        }

        public MoveAnimal GetBird(float power)
        {
            if (withoutPower)
            {
                if (_moveAnimals.Count > 0) return _moveAnimals[0];
                return null;
            }

            MoveAnimal animal = null;
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

            foreach (var t in _moveAnimals)
            {
                if (t.time < boundary && t.time > max)
                {
                    max = t.time;
                    animal = t;
                }
            }

            return animal;
        }
    }
}