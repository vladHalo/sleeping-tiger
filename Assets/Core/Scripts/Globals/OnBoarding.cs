using Core.Scripts.Views;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OnBoarding : MonoBehaviour
{
    [SerializeField] private Button[] _nextStepBtn;

    [SerializeField] private BoardStep[] _steps;

    private int _stepIndex;
    [Inject] private GameManager _gameManager;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(Str.Board))
        {
            foreach (var i in _nextStepBtn)
            {
                i.onClick.AddListener(NextStep);
            }

            _steps[_stepIndex].ActiveStep();
        }
    }

    public void NextStep()
    {
        _stepIndex++;
        if (_stepIndex == _steps.Length - 1)
        {
            _gameManager.statusGame = StatusGame.Play;
            PlayerPrefs.SetInt(Str.Board, 1);
        }

        _steps[_stepIndex].ActiveStep();
    }
}

[System.Serializable]
public class BoardStep
{
    [SerializeField] private GameObject[] on;
    [SerializeField] private GameObject[] off;

    public void ActiveStep()
    {
        foreach (var i in on)
            i.SetActive(true);

        foreach (var i in off)
            i.SetActive(false);
    }
}