using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsGallina : IACharacterActions
{
    void Awake()
    {
        // Es crucial llamar a LoadComponent para que las referencias a 'hunger' 
        // y 'AIEye' (heredadas de IACharacterControl) se inicialicen.
        LoadComponent();
    }


    public override void LoadComponent()
    {
        base.LoadComponent();

    }
  
}
