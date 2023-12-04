using System;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class ViewManager : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button[] _restartButtons;

        private void Start()
        {
            _pauseButton.onClick.AddListener(PauseLevel);
            _restartButtons[0].onClick.AddListener(RestartLevel);
            _restartButtons[1].onClick.AddListener(RestartLevelGame);
            _restartButtons[2].onClick.AddListener(RestartLevelGame);

            _restartButtons[3].onClick.AddListener(RestartLevel);
            _restartButtons[4].onClick.AddListener(RestartLevel);
        }

        private void PauseLevel()
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }

        private void RestartLevel()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(Str.Main);
        }

        private void RestartLevelGame()
        {
            Time.timeScale = 1;
            PlayerPrefs.SetInt(Str.GameStart, 0);
            SceneManager.LoadScene(Str.Main);
        }

        private void OnApplicationQuit()
        {
            if (PlayerPrefs.HasKey(Str.GameStart))
                PlayerPrefs.DeleteKey(Str.GameStart);
        }
    }
}