using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMolecule : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationY;

    private float rotateSpeed = 0.2f;
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Debug.Log("TOCANDO NA TELA");
            if(touch.phase == TouchPhase.Moved)
            {
                 Debug.Log("TOCANDO NA TELA");
                rotationY = Quaternion.Euler(0f, touch.deltaPosition.x * rotateSpeed, 0f);

                transform.rotation = rotationY * transform.rotation;
            }
        }
    }
}
