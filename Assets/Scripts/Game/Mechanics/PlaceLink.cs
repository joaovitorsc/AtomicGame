using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLink : MonoBehaviour
{
       public bool isValid, Horizontal, Diagonal_Dir, Diagonal_Esq;

void Start()
   {
      if (!isValid)
      {
         FindObjectOfType<AudioManager>().Play("Correct");
      } 
   }
}
