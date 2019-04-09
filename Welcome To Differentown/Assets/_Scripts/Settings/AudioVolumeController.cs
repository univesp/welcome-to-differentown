using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioVolumeController : MonoBehaviour {

    public AudioMixer masterMixer;

    [Header("BGM")]
    public Slider bgmSlider;

    [Header("SFX")]
    public Slider sfxSlider;

    //Variável auxiliar para pegar o valor do mixer
    private float value;

    //Inicia o slider na última posição deixada pelo jogador
    private void OnEnable()
    {
        if(masterMixer.GetFloat("BGMVolume", out value))
        {
            bgmSlider.value = value;
        }

        if (masterMixer.GetFloat("SFXVolume", out value))
        {
            sfxSlider.value = value;
        }
    }

    //Ao iniciar o script, ele delega essas funções ao slider
    private void Start()
    {
        bgmSlider.onValueChanged.AddListener(delegate { ChangeBGMVolume(); });
        bgmSlider.onValueChanged.AddListener(delegate { ChangeNoiseVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { ChangeSFXVolume(); });        
    }

    private void ChangeBGMVolume()
    {
        masterMixer.SetFloat("BGMVolume", bgmSlider.value);
    }

    private void ChangeSFXVolume()
    {
        masterMixer.SetFloat("SFXVolume", sfxSlider.value);
    }

    private void ChangeNoiseVolume()
    {
        masterMixer.SetFloat("NoiseVolume", bgmSlider.value);
    }
}
