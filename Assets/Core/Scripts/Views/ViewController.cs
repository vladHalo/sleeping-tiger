using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class ViewController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _panels;
        [SerializeField] private List<Button> _buttons;

        private bool _isPause;

        private void Awake()
        {
            Time.timeScale = 0;

            _buttons[0].onClick.AddListener(BtnPlay);
            _buttons[1].onClick.AddListener(BtnRestartLevel);
            _buttons[2].onClick.AddListener(BtnRestartLevel);
            _buttons[3].onClick.AddListener(BtnPause);
        }

        public void OpenLosePanel()
        {
            _panels[1].SetActive(true);
            _panels[2].SetActive(false);
        }

        private void BtnPause()
        {
            Time.timeScale = _isPause ? 1 : 0;
            _isPause = !_isPause;
        }

        private void BtnPlay()
        {
            Time.timeScale = 1;
            _panels[0].SetActive(false);
        }

        private void BtnRestartLevel() => SceneManager.LoadScene(SceneManager.sceneCount - 1);
    }
}