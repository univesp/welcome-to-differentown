using UnityEngine;

public class OptionsState : MonoBehaviour {

    //Essa função é para o player não conseguir interagir com o jogo enquanto o menu de opções estiver ativo
    public bool isInOptionsScreen;

    static public OptionsState instance;

    public void Awake()
    {
        instance = this;
    }

    //Essa função é chamada pelos botões de entrar e sair das opções
    public void SetOptionScreen(bool state)
    {
        isInOptionsScreen = state;
    }
}
