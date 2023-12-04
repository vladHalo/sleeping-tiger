using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class ActionButtonManager : MonoBehaviour
    {
        [SerializeField] private List<ButtonModel> _buttonsList;
        private readonly string[] Prefixs = { "-Image", "-Color", "-Text" };

        private void Start()
        {
            _buttonsList.ForEach((item, index) =>
            {
                if (item.button != null)
                {
                    item.button.onClick.AddListener(() => { ChangeButtons(index); });
                }
            });
            StartChangeButton();
        }

        public void ChangeButtons(int number)
        {
            _buttonsList.ForEach((x, index) => { RefreshButton(index); });
            ChangeButton(number);
        }

        private void RefreshButton(int index)
        {
            if (_buttonsList[index].image != null && _buttonsList[index].sprites.Count >= 2)
            {
                _buttonsList[index].image.sprite = _buttonsList[index].sprites[0];
                if (!string.IsNullOrEmpty(_buttonsList[index].nameSave))
                    ES3.Save(_buttonsList[index].nameSave + Prefixs[0], 0);
            }

            if (_buttonsList[index].image != null && _buttonsList[index].colors.Count >= 2)
            {
                _buttonsList[index].image.color = _buttonsList[index].colors[0];
                if (!string.IsNullOrEmpty(_buttonsList[index].nameSave))
                    ES3.Save(_buttonsList[index].nameSave + Prefixs[1], 0);
            }

            if (_buttonsList[index].text != null && _buttonsList[index].texts.Count >= 2)
            {
                _buttonsList[index].text.text = _buttonsList[index].texts[0];
                if (!string.IsNullOrEmpty(_buttonsList[index].nameSave))
                    ES3.Save(_buttonsList[index].nameSave + Prefixs[2], 0);
            }
        }

        private void ChangeButton(int index)
        {
            if (_buttonsList[index].image != null && _buttonsList[index].sprites.Count >= 2)
            {
                int number = _buttonsList[index].image.sprite == _buttonsList[index].sprites[0] ? 1 : 0;
                _buttonsList[index].image.sprite = _buttonsList[index].sprites[number];
                if (!string.IsNullOrEmpty(_buttonsList[index].nameSave))
                    ES3.Save(_buttonsList[index].nameSave + Prefixs[0], number);
            }

            if (_buttonsList[index].image != null && _buttonsList[index].colors.Count >= 2)
            {
                int number = _buttonsList[index].image.color == _buttonsList[index].colors[0] ? 1 : 0;
                _buttonsList[index].image.color = _buttonsList[index].colors[number];
                if (!string.IsNullOrEmpty(_buttonsList[index].nameSave))
                    ES3.Save(_buttonsList[index].nameSave + Prefixs[1], number);
            }

            if (_buttonsList[index].text != null && _buttonsList[index].texts.Count >= 2)
            {
                int number = _buttonsList[index].text.text == _buttonsList[index].texts[0] ? 1 : 0;
                _buttonsList[index].text.text = _buttonsList[index].texts[number];
                if (!string.IsNullOrEmpty(_buttonsList[index].nameSave))
                    ES3.Save(_buttonsList[index].nameSave + Prefixs[2], number);
            }
        }

        private void StartChangeButton()
        {
            foreach (var t in _buttonsList)
            {
                if (string.IsNullOrEmpty(t.nameSave)) continue;

                if (ES3.KeyExists(t.nameSave + Prefixs[0]) && t.image != null)
                {
                    int index = ES3.Load<int>(t.nameSave + Prefixs[0]);
                    t.image.sprite = t.sprites[index];
                }

                if (ES3.KeyExists(t.nameSave + Prefixs[1]) && t.image != null)
                {
                    int index = ES3.Load<int>(t.nameSave + Prefixs[1]);
                    t.image.color = t.colors[index];
                }

                if (ES3.KeyExists(t.nameSave + Prefixs[2]) && t.text != null)
                {
                    int index = ES3.Load<int>(t.nameSave + Prefixs[2]);
                    t.text.text = t.texts[index];
                }
            }
        }

        [Serializable]
        private class ButtonModel
        {
            public string nameSave;
            public Button button;
            public Image image;
            public Text text;
            [ShowIf("ButtonImageNotNull")] public List<Sprite> sprites;
            [ShowIf("ButtonImageNotNull")] public List<Color> colors;
            [ShowIf("text")] public List<string> texts;

            private bool ButtonImageNotNull()
            {
                return button != null && image != null;
            }
        }
    }
}