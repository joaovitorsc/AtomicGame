using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScenes : MonoBehaviour
{
   public void LoadNextScene(string scene)
   {
       SceneManager.LoadScene(scene);
   }
}
