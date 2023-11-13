using System.Collections.Generic;
//using _1Core.Scripts.Bot;
using UnityEngine;

namespace _1Core.Scripts.Player
{
    public class PlayerTrigger : MonoBehaviour
    {
        //[SerializeField] private List<AIBotController> _bots;

        private void OnTriggerEnter(Collider other)
        {
            //if (other.TryGetComponent(out AIBotController aIBot))
            {
            //    _bots.Add(aIBot);
            }
        }

        public void RemoveEnemy()
        {
            //if (_bots.Count > 0)
            {
            //    _bots.RemoveAt(0);
            }
        }

        // public AIBotController GetEnemy()
        // {
        //     if (_bots.Count > 0)
        //         return _bots[0];
        //     return null;
        // }
    }
}