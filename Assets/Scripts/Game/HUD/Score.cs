using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreTXT, TimerTXT;
    int ScoreNumber;
    public float TimeLeft;
    float actualTime;

    GameObject HUDManager;
    public GameObject GameOverPanel;


   void Start() 
   {
       HUDManager = GameObject.FindGameObjectWithTag("HUD");
   }
    void Update() 
   {
      
      CountTimer();
      ScoreCount();
    
   }

   void CountTimer()
   {
   
    if (!HUDManager.GetComponent<ChecarEstado>().completou)
    {
        TimerTXT.text = TimeLeft.ToString("0");
        actualTime = TimeLeft;
        if ( TimeLeft < 0 )
        {
            TimeLeft =0;
            Debug.Log("PERDEU");
            GameOverPanel.SetActive(true);

        }
        else
        {
            TimeLeft -= Time.deltaTime;
        }
    }
   }

   void ScoreCount()
   {
        if (HUDManager.GetComponent<ChecarEstado>().completou && TimeLeft >= 0)
        {
            //TimeLeft = actualTime; 
           for(int  i = 0; i < TimeLeft; i++)
           {
                ScoreNumber += 10;
                ScoreTXT.text = ScoreNumber.ToString();
                TimerTXT.text = TimeLeft.ToString("0");
                TimeLeft--;
           }
           /*
           if (TimeLeft >=0)
           {
                ScoreNumber += 10;
                ScoreTXT.text = ScoreNumber.ToString();
                TimerTXT.text = TimeLeft.ToString();
                TimeLeft--;
           }
           */
        }
    }
}
