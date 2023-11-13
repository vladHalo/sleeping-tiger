//using _1Core.Scripts.Bullet;
using _1Core.Scripts.Interfaces;
using _1Core.Scripts.Player.Models;

namespace _1Core.Scripts.Player.States
{
    public class DeadState : IState
    {
        private readonly PlayerStateManager _player;
        private readonly PlayerAnimation _playerAnimation;

        public DeadState(PlayerStateManager player, DeadModel deadModel)
        {
            _player = player;
        }

        public void EnterState()
        {
            //_playerAnimation.SetAnimation(Str.Dead);
        }

        public void UpdateState()
        {

        }

        public void ExitState()
        {
        }
    }
}