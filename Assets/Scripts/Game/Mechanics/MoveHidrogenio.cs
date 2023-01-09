using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHidrogenio : MonoBehaviour
{
       Vector3 Pos_Start, Pos_Destiny, Vector_Direction;
    Rigidbody _rigidbody3D;
    bool isHolding;
    float distance;
    PlaceAtomo Pa;
    public bool ValidPlace ;
   
    public bool isConnected;
    [Range(1,15)]
    public float Speed_Move;
    [Space (10)]
    public GameObject[] Connects;
    [Range(0.1f, 2.0f)]
    public float DistanceMinConnect;
    [HideInInspector]
    public bool allAreTrue = false;
    void Start()
    {
        
        ValidPlace = false;
        Connects = GameObject.FindGameObjectsWithTag("ConnectHidrogen");
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
                     Pa= Connect.GetComponent<PlaceAtomo>();
                     distance = Vector3.Distance(transform.position, Connect.transform.position);
                    
                    if (distance < DistanceMinConnect && Pa.isValid)
                    {
                        _rigidbody3D.velocity = Vector3.zero;
                        transform.position = Vector3.MoveTowards(transform.position, Connect.transform.position, 0.02f);   
                    }

                    if (distance <0.01f)
                    {

                        FindObjectOfType<AudioManager>().Play("Correct");
                        Pa.isValid = false;
                        Debug.Log("A BRBA");
                        isConnected = true;
                        transform.position = Connect.transform.position;
                        this.ValidPlace = true;
                        
                    } 
                    if (!isConnected && !Pa.isValid && distance < DistanceMinConnect && ValidPlace)
                   {
                       Pa.isValid = true;
                       
                   } 
                }
            }
    }
}
