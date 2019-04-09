using UnityEngine;
using UnityEngine.Events;

public class FillBlankSentenceController : MonoBehaviour {

    public FillBlankSpace[] blankSpace;
    public UnityEvent actions;

    //Verifica se os espaços em branco foram preenchidos e retorna true ou false
    public bool CheckCompleteness()
    {
        foreach(FillBlankSpace space in blankSpace)
        {
            if(!space.isCompleted)
            {
                return false;
            }
        }
        return true;
    }
}
