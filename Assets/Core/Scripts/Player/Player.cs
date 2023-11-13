using UnityEngine;

namespace Core.Scripts.Player
{
    public abstract class Player : MonoBehaviour
    {
        //[SerializeField] protected Joystick _joystick;
        [SerializeField] protected float _speed;
    }
}