using Core.Scripts.Interfaces;
using Core.Scripts.Player.Models;

namespace Core.Scripts.Player.States
{
    public class ShotState : IState
    {
        private readonly PlayerStateManager _player;
        //private readonly BulletMove _bulletMove;

        public ShotState(PlayerStateManager player, ShotModel shotModel)
        {
            _player = player;
            //_bulletMove = shotModel.bulletMove;
        }

        public void EnterState()
        {
            //_player.playerAnimation.SetAnimation(Str.Shot);
        }

        public void UpdateState()
        {
            //if (_player.target == null) _player.SetState(_player.rotateState);
            //if (!_bulletMove.gameObject.activeSelf)
                //_player.playerAnimation.SetAnimation(Str.Shot);
        }

        public void ExitState()
        {
        }
    }
}