using UnityEngine;

public class ProtectObjectFromDestruction : MonoBehaviour {

    //Qualquer objeto que conter esse script não será destruído na troca de cenas
    public static ProtectObjectFromDestruction instance;

    //Se o objeto não existir, ele cria a instância. Senão, ele destrói o objeto
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Quando um objeto estático é destruído, ele não se destrói por completo. Para que ele seja pego pelo Garbage Collector, vc precisa nullificar ele manualmente. Essa função faz isso
    private void OnDestroy()
    {
        instance = null;
    }
}
