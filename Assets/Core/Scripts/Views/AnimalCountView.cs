using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Scripts.Views
{
    public class AnimalCountView : MonoBehaviour
    {
        [SerializeField] private ActionPanelManager _actionView;
        [SerializeField] private Text _animalsCountUI;
        [SerializeField] private Text _bestScore;
        [SerializeField] private Text _animalsCountFinishUI;
        [SerializeField] private Image _progressLevel;
        private int _count, _bestCount, _startCount;

        [Inject] private GameManager _gameManager;

        public int indexPointAdd;
        
        private void Start()
        {
            indexPointAdd = 1;
            if (PlayerPrefs.HasKey(Str.BestScore))
            {
                _bestCount = PlayerPrefs.GetInt(Str.BestScore);
                _bestScore.text = $"{_bestCount}";
                _count = PlayerPrefs.GetInt(Str.Score, _count);
                _animalsCountUI.text = $"{_count}";
                _startCount = _count;
            }

            _animalsCountFinishUI.text = $"{_gameManager.GetLevelScoreForWin()}";
        }

        public void AddCount()
        {
            float finishScore = _gameManager.GetLevelScoreForWin();
            _count += indexPointAdd;
            _progressLevel.fillAmount = (_count - _startCount) / (finishScore - _startCount);
            _animalsCountUI.text = _count.ToString();
            if (_count > _bestCount)
                _bestScore.text = $"{_count}";
            if (_count > _bestCount)
                PlayerPrefs.SetInt(Str.BestScore, _count);

            if (_count >= finishScore)
            {
                PlayerPrefs.SetInt(Str.Score, _count);
                Time.timeScale = 0;
                _actionView.OpenPanels(1);
                _gameManager.Win();
            }
        }
    }
}