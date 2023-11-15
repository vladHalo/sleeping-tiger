using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class ViewController : MonoBehaviour
    {
        [Header("PauseImg")] [SerializeField] private Image _pauseImg;
        [SerializeField] private Image _musicImg, _soundImg;
        [SerializeField] private Sprite[] _spritesPause, _spritesMusic, _spritesSound;
        [Space] [SerializeField] private List<GameObject> _panels;
        [SerializeField] private List<Button> _buttons;
        [SerializeField] private GameObject _birdSpawn;

        private bool _isPause, _isMusic, _isSound;

        private void Awake()
        {
            _buttons[0].onClick.AddListener(Play);
            _buttons[1].onClick.AddListener(RestartLevel);
            _buttons[2].onClick.AddListener(RestartLevel);
            _buttons[3].onClick.AddListener(PauseOnOff);
            _buttons[4].onClick.AddListener(() => ChangeImage(ref _isMusic, _musicImg, _spritesMusic));
            _buttons[5].onClick.AddListener(() => ChangeImage(ref _isSound, _soundImg, _spritesSound));

            if (PlayerPrefs.HasKey(Str.Music))
            {
                var value = PlayerPrefs.GetInt(Str.Music);
                _isMusic = value != 0;
                ChangeImage(ref _isMusic, _musicImg, _spritesMusic);
            }

            if (PlayerPrefs.HasKey(Str.Sound))
            {
                var value = PlayerPrefs.GetInt(Str.Sound);
                _isSound = value != 0;
                ChangeImage(ref _isSound, _soundImg, _spritesSound);
            }
        }

        public void OpenLosePanel()
        {
            _panels[1].SetActive(true);
            _panels[2].SetActive(false);
        }

        private void PauseOnOff()
        {
            int index = _isPause ? 1 : 0;
            Time.timeScale = index;
            ChangeImage(ref _isPause, _pauseImg, _spritesPause);
        }

        private void Play()
        {
            _panels[0].SetActive(false);
            if (PlayerPrefs.HasKey(Str.Board))
                _birdSpawn.SetActive(true);
        }

        private void ChangeImage(ref bool isActive, Image image, Sprite[] sprites)
        {
            int index = isActive ? 1 : 0;
            isActive = !isActive;
            image.sprite = sprites[index];
        }

        private void RestartLevel() => SceneManager.LoadScene(Str.Main);
    }
}