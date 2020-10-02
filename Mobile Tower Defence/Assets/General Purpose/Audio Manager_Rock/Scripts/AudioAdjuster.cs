using UnityEngine;
using UnityEngine.UI;

public class AudioAdjuster : MonoBehaviour
{
    [SerializeField] private Slider sfxSlider = null;
    [SerializeField] private Slider bgmSlider = null;

    static private float sfxVolume = 0.5f;
    static private float bgmVolume = 0.5f;

    private void Start()
    {
        sfxSlider.onValueChanged.AddListener(AdjustSfxVolume);
        bgmSlider.onValueChanged.AddListener(AdjustBgmVolume);

        AudioManager.SfxVolume = sfxSlider.value = sfxVolume;
        AudioManager.BgmVolume = bgmSlider.value = bgmVolume;
    }

    public void AdjustSfxVolume(float value)
    {
        sfxVolume = AudioManager.SfxVolume = value;
    }
    public void AdjustBgmVolume(float value)
    {
        bgmVolume = AudioManager.BgmVolume = value;
    }
}
