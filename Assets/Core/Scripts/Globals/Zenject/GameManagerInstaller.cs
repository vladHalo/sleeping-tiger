using Zenject;

public class GameManagerInstaller : MonoInstaller
{
    public GameManager _gameManager;
    public AudioManager _audioManager;

    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle().NonLazy();
        Container.QueueForInject(_gameManager);
        
        Container.Bind<AudioManager>().FromInstance(_audioManager).AsSingle().NonLazy();
        Container.QueueForInject(_audioManager);
    }
}