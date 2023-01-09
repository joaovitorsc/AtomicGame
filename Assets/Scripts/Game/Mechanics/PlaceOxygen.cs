using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOxygen : MonoBehaviour
{
     public bool isValid;


 void Start()
   {
      if (!isValid)
      {
         FindObjectOfType<AudioManager>().Play("Correct");
      } 
   }
}
