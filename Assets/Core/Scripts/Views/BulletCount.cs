using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class BulletCount : MonoBehaviour
    {
        [SerializeField] private Text _bulletCountUI;

        private int _count;

        public void Refresh()
        {
            _count++;
            _bulletCountUI.text = $"Bullets: {_count}";
        }
    }
}