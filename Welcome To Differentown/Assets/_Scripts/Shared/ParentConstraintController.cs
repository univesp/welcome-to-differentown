using UnityEngine;
using UnityEngine.Animations;

//Esse script é chamado dentro das animações quando precisam ativar ou desativar o parent constraint do objeto
public class ParentConstraintController : MonoBehaviour {

    public ParentConstraint[] parentConstraint;
    private int index;

    public void SetActive()
    {
        index = 0;
        foreach(ParentConstraint constrain in parentConstraint)
        {
            parentConstraint[index].enabled = true;
            index++;
        }
    }

    public void SetInactive()
    {
        index = 0;
        foreach (ParentConstraint constrain in parentConstraint)
        {
            parentConstraint[index].enabled = false;
            index++;
        }
    }
}
