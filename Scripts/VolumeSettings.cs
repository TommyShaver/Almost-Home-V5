using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    private void Start()
    {
        MySliderVolume();
        MySliderSFX();
    }

    public void MySliderVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("MusicSliderFun", Mathf.Log10(volume) * 20);
    }
    public void MySliderSFX()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFXSliderFun", Mathf.Log10(volume) * 20);
    }
}
