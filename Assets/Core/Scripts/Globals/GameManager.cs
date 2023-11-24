using Core.Scripts.Bird;
using Core.Scripts.Store;
using Core.Scripts.Tiger;
using Core.Scripts.Views;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _startBtn;

    public TigerStateManager tigerStateManager;
    public FactoryAnimal factoryAnimal;
    public AnimalCountView animalCountView;
    public AbilityView abilityView;
    public StoreLogic storeLogic;
    public StatusGame statusGame;

    [Header("Level")] public Text levelTextUI;
    public int level;
    public int levelText;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(Str.Level))
        {
            levelText = PlayerPrefs.GetInt(Str.Level);
            levelTextUI.text = $"Lvl {levelText + 1}";
            level = levelText;

            if (levelText >= 3)
            {
                level = Random.Range(0, 4);
            }
        }

        _startBtn.onClick.AddListener(() =>
        {
            if (PlayerPrefs.HasKey(Str.Board))
                statusGame = StatusGame.Play;
        });
    }

    public int GetLevelScoreForWin() => 10 * (levelText + 1) * (levelText + 1);

    public void Win()
    {
        level++;
        levelText++;
        PlayerPrefs.SetInt(Str.Level, levelText);
    }
}