using UnityEngine;

namespace _1Core.Scripts.Player
{
    public class PlayerShot : MonoBehaviour
    {
        [SerializeField] private PlayerStateManager _player;
        [SerializeField] private Transform _aim;

        public void Shot()
        {
            //_bulletMove.Init(_aim, _player.target.transform);
        }
    }
}