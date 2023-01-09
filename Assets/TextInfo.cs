using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInfo : MonoBehaviour
{
    GameObject User;

    private void Start()
    {
        User = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update()
    {
        transform.LookAt(User.transform);
    }
}
