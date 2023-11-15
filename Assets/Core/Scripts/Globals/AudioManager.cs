using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundEffectSource;

    private bool _isMusic, _isSound;

    private void Start()
    {
        _buttons[0].onClick.AddListener(() => SetVolume(ref _isMusic, Str.Music, _musicSource));
        _buttons[1].onClick.AddListener(() => SetVolume(ref _isSound, Str.Sound, _soundEffectSource));

        if (PlayerPrefs.HasKey(Str.Music))
        {
            var value = PlayerPrefs.GetInt(Str.Music);
            _isMusic = value == 0;
            _musicSource.volume = value;
        }

        if (PlayerPrefs.HasKey(Str.Sound))
        {
            var value = PlayerPrefs.GetInt(Str.Sound);
            _isSound = value == 0;
            _soundEffectSource.volume = value;
        }
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        _soundEffectSource.clip = clip;
        _soundEffectSource.Play();
    }

    private void SetVolume(ref bool value, string musicSound, AudioSource manager)
    {
        manager.volume = value ? 1 : 0;
        var index = value ? 1 : 0;
        PlayerPrefs.SetInt(musicSound, index);
        value = !value;
    }
}