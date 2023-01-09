using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberMolecules : MonoBehaviour
{

     int NumberOfMolecules = 0;
    public void LimitMolecules(int NumberMaxOfMolecules)
    {
        NumberOfMolecules++;
        if (NumberOfMolecules >= NumberMaxOfMolecules)
        {
            this.gameObject.SetActive(false);
        }
    }
}
