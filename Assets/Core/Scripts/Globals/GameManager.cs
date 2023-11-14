using Core.Scripts.Bird;
using Core.Scripts.Tiger;
using Core.Scripts.Views;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TigerStateManager tigerStateManager;
    public SpawnBird spawnBird;
    public BirdCountView birdCountView;
    public AbilityView abilityView;
    public StatusGame statusGame;

    public void ChangeStatus() => statusGame = StatusGame.Lose;
}