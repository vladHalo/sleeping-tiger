using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class ActionButtonUpgradeManager : MonoBehaviour
    {
        [SerializeField] private bool _onStartListener;
        [SerializeField] private List<ButtonModel> _buttonsList;
        private readonly string Prefix = "-Upgrade";

        private void Start()
        {
            if (_onStartListener)
            {
                AddListener(NextStep);
            }

            StartChangeButton();
        }

        public void AddListener(Action<int> method)
        {
            _buttonsList.ForEach((item, index) =>
            {
                if (item.button != null)
                {
                    item.button.onClick.AddListener(() => { method(index); });
                }
            });
        }

        public void NextStep(int index)
        {
            _buttonsList[index].images[_buttonsList[index].step].sprite = _buttonsList[index].sprite;
            _buttonsList[index].step++;
            if (!string.IsNullOrEmpty(_buttonsList[index].nameSave))
                ES3.Save(_buttonsList[index].nameSave + Prefix, _buttonsList[index].step);
            if (_buttonsList[index].step >= _buttonsList[index].images.Count)
            {
                _buttonsList[index].button.interactable = false;
            }
        }

        private void StartChangeButton()
        {
            int index = 0;
            foreach (var t in _buttonsList)
            {
                if (string.IsNullOrEmpty(t.nameSave)) continue;

                if (ES3.KeyExists(t.nameSave + Prefix) && t.sprite != null)
                {
                    index = ES3.Load<int>(t.nameSave + Prefix);
                    t.step = index;
                    for (int i = 0; i < index; i++)
                    {
                        t.images[i].sprite = t.sprite;
                    }
                }

                if (index >= t.images.Count)
                {
                    _buttonsList[index].button.interactable = false;
                }
            }
        }

        [Serializable]
        private class ButtonModel
        {
            public string nameSave;
            [HideInInspector] public int step;
            public Button button;
            public Sprite sprite;
            [ShowIf("ButtonSpriteNotNull")] public List<Image> images;

            private bool ButtonSpriteNotNull()
            {
                return button != null && sprite != null;
            }
        }
    }
}