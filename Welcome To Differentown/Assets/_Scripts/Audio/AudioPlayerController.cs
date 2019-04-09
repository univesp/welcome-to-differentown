using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioPlayerController : MonoBehaviour {

    public AudioSource SFX;

    [Header("Noise Variables")]
    private bool turnOffNoise;
    private bool turnOnNoise;
   
    [SerializeField]
    private AudioClip SFX_MouseOver;
    [SerializeField]
    private AudioClip SFX_MouseClick;
    [SerializeField]
    private AudioClip SFX_InicioJogo;
    [SerializeField]
    private AudioClip SFX_FalaSurgindo;
    [SerializeField]
    private AudioClip SFX_OpcaoClick;
    [SerializeField]
    private AudioClip SFX_MapaGeralSurgindo;
    [SerializeField]
    private AudioClip SFX_Carro;
    [SerializeField]
    private AudioClip SFX_Erro;
    [SerializeField]
    private AudioClip SFX_Acerto;
    [SerializeField]
    private AudioClip SFX_Fim;
    [SerializeField]
    private AudioClip SFX_Passaporte;

    public static AudioPlayerController instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        instance = null;
    }

    #region SFX Funções
    public void PlaySFX_MouseOver()
    {
        SFX.PlayOneShot(SFX_MouseOver);
    }

    public void PlaySFX_MouseClick()
    {
        SFX.PlayOneShot(SFX_MouseClick);
    }

    public void PlaySFX_InicioJogo()
    {
        SFX.PlayOneShot(SFX_InicioJogo);
    }

    public void PlaySFX_FalaSurgindo()
    {
        SFX.PlayOneShot(SFX_FalaSurgindo);
    }

    public void PlaySFX_OpcaoClick()
    {
        SFX.PlayOneShot(SFX_OpcaoClick);
    }

    public void PlaySFX_MapaGeralSurgindo()
    {
        SFX.PlayOneShot(SFX_MapaGeralSurgindo);
    }

    public void PlaySFX_Carro()
    {
        SFX.PlayOneShot(SFX_Carro);
    }

    public void PlaySFX_Erro()
    {
        SFX.PlayOneShot(SFX_Erro);
    }

    public void PlaySFX_Acerto()
    {
        SFX.PlayOneShot(SFX_Acerto);
    }

    public void PlaySFX_Fim()
    {
        SFX.PlayOneShot(SFX_Fim);
    }

    public void PlaySFX_Passaporte()
    {
        SFX.PlayOneShot(SFX_Passaporte);
    }

    public void StopSFX()
    {
        SFX.Stop();
    }
    #endregion
}