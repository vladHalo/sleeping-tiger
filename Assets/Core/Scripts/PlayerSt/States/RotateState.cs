using _1Core.Scripts.Interfaces;
using _1Core.Scripts.Player.Models;
using UnityEngine;

namespace _1Core.Scripts.Player.States
{
    public class RotateState : IState
    {
        private readonly PlayerStateManager _player;
        private readonly float _speedRotate;


        public RotateState(PlayerStateManager player, RotateModel rotateModel)
        {
            _player = player;
            _speedRotate = rotateModel.speedRotate;
        }

        public void EnterState()
        {
            //_player.playerAnimation.SetAnimation(Str.Idle);
        }

        public void UpdateState()
        {
            //if (_player.target == null) return;
            Vector3 direction = new Vector3(); //(_player.target.transform.position - _player.transform.position).normalized;
            _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation,
                Quaternion.LookRotation(direction),
                Time.fixedDeltaTime * _speedRotate);
            _player.transform.eulerAngles = new Vector3(0, _player.transform.eulerAngles.y, 0);

            if (IsRotationComplete()) _player.SetState(_player.shotState);
        }

        public void ExitState()
        {
        }

        private bool IsRotationComplete()
        {
            Vector3 direction = new Vector3();// (_player.target.transform.position - _player.transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            float angleDifferenceY = Mathf.Abs(_player.transform.rotation.eulerAngles.y - targetRotation.eulerAngles.y);

            return angleDifferenceY < 0.3f;
        }
    }
}