using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecarEstado : MonoBehaviour
{
    public bool completou;

    public GameObject Button3Dto2D,BTN_NextFase;
    GameObject [] CHidrogenios;
    GameObject [] CCarbons;
    GameObject [] CLinks;

    GameObject [] OxygenLinks;

    float cronometro;

        private bool Hidroconnetecds, CarbonConnetecds, LinkConnetecds, OxygenConnecteds;
       

        void Start () 
        {
            
            cronometro = 0;
            completou = false;

            

            CHidrogenios = GameObject.FindGameObjectsWithTag("ConnectHidrogen");
            CCarbons = GameObject.FindGameObjectsWithTag("ConnectCarbon");
            CLinks = GameObject.FindGameObjectsWithTag("ConnectLink");
            OxygenLinks = GameObject.FindGameObjectsWithTag("ConnectOxygen");
        

        }

        void Update()
        {
            CheckHidrogenio();
            CheckCarbon(); 
            CheckLinks();
            CheckOxygen(); 
            CompleteFase();     
        }
        void CheckHidrogenio()
        {
            bool unfinishedLinks = false;
            for (var i = 0; i<  CHidrogenios.Length; i++)
            {
                if (CHidrogenios[i].GetComponent<PlaceAtomo>().isValid)
                    {
                        unfinishedLinks = true;
                        break;
                    }        
            }
             if(!unfinishedLinks)
                {
                    Hidroconnetecds = true;
                }
        }
        void CheckCarbon()
        {
             bool unfinishedLinks = false;
            for (var i = 0; i < CCarbons.Length; i++)
            {
                if (CCarbons[i].GetComponent<PlaceAtomo>().isValid)
                    {
                        unfinishedLinks = true;
                        break;
                    }
            }
             if(!unfinishedLinks)
                {
                    CarbonConnetecds = true;
                }
        }
        void CheckLinks()
        {
            bool unfinishedLinks = false;
            for (var i = 0; i < CLinks.Length; i++)
            {
                if(CLinks[i].GetComponent<PlaceLink>().isValid)
                {
                   unfinishedLinks = true;
                   break;
                }
            }
            if(!unfinishedLinks)
                {
                    LinkConnetecds = true;
                }
            /*
           bool allAreTrue = false;
            foreach (var Links in CLinks)
            {
                if (Links.GetComponent<PlaceLink>())
                {
                    Debug.Log("Existe 1 ativado");
                    allAreTrue = true;

                }
                if(allAreTrue == false)
                {
                    LinkConnetecds = true;
                    
                }
                
                            
            }*/
        }
        void CheckOxygen()
        {
             bool unfinishedLinks = false;
            for (var i = 0; i < OxygenLinks.Length; i++)
            {
                if (OxygenLinks[i].GetComponent<PlaceOxygen>().isValid)
                    {
                        unfinishedLinks = true;
                        break;
                    }
            }
             if(!unfinishedLinks)
                {
                    OxygenConnecteds = true;
                }
        }
        void CompleteFase()
        {
            if (Hidroconnetecds && CarbonConnetecds && LinkConnetecds && OxygenConnecteds )
            completou = true;
            
            if(completou && !GetComponent<HUD>().Active3D )
            {
                Button3Dto2D.SetActive(true);
                BTN_NextFase.SetActive(true);
            }
            
        }
}
