using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class BirdCountView : MonoBehaviour
    {
        [SerializeField] private Text _birdsCountUI;
        private int _count;

        public void RefreshCount()
        {
            _count++;
            _birdsCountUI.text = $"Birds: {_count}";
        }
    }
}