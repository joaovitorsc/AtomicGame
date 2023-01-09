using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLink : MonoBehaviour
{
   
       Vector3 Pos_Start, Pos_Destiny, Vector_Direction;
    Rigidbody _rigidbody3D;
    bool isHolding;
    float distance;
    PlaceLink Pl;
    public bool ValidPlace ;
    [HideInInspector]
    public bool isConnected;
    [Range(1,15)]
    public float Speed_Move;
    [Space (10)]
    public GameObject[] Connects;
    [Range(0.1f, 2.0f)]
    public float DistanceMinConnect;
    [HideInInspector]
    
    void Start()
    {
        
        ValidPlace = false;
        Connects = GameObject.FindGameObjectsWithTag("ConnectLink");
        _rigidbody3D = transform.GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        Pos_Start = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isHolding = true;
        isConnected = false;
        Debug.Log("CLICANDO");

    }
    private void OnMouseDrag() 
    {
        Pos_Destiny = Pos_Start +  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector_Direction = Pos_Destiny - transform.position;
        _rigidbody3D.velocity = Vector_Direction * Speed_Move;

    }
    private void OnMouseUp() 
    {
       isHolding = false; 
       _rigidbody3D.velocity = new Vector3(0,0,0);
    }
    
    void FixedUpdate() 
    {
            if (!isHolding && !isConnected)
            {
                foreach (GameObject Connect in Connects)
                {
                    Pl= Connect.GetComponent<PlaceLink>();
                     distance = Vector3.Distance(transform.position, Connect.transform.position);
                    if (distance < DistanceMinConnect && Pl.isValid)
                    {
                        
                        _rigidbody3D.velocity = Vector3.zero;
                        transform.position = Vector3.MoveTowards(transform.position, Connect.transform.position, 0.02f);   
                    }

                    if (distance <0.01f)
                    {
                        if(Pl.Horizontal)
                        {
                            this.transform.Rotate(0,0,90);
                        }
                        if(Pl.Diagonal_Dir)
                        {
                            this.transform.Rotate(0,0,-60);
                            Debug.Log("DIREITA");
                        }
                        
                        if(Pl.Diagonal_Esq)
                        {
                            this.transform.Rotate(0,0,60);
                            Debug.Log("ESQUERDA");
                        }
                        
                        FindObjectOfType<AudioManager>().Play("Correct");
                        Pl.isValid = false;
                        Debug.Log("A BRBA");
                        isConnected = true;
                        transform.position = Connect.transform.position;
                        this.ValidPlace = true;
                    } 
                    if (!isConnected && !Pl.isValid && distance < DistanceMinConnect && ValidPlace)
                   {
                       Pl.isValid = true;
                       
                   } 
                  
                }
            }
    }
}

