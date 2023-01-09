using UnityEngine.UI;

using UnityEngine;

public class HUD : MonoBehaviour
{
    public bool Active3D = false;
    public Transform SpanwElements;
    private GameObject Elements;

    public GameObject btn_2D, btn_3D;

    void Start()
    {
        Elements = GameObject.FindGameObjectWithTag("Molecula");
        
    }
    public void InstanceElement(GameObject prefab)
    {
       GameObject Atomo = Instantiate(prefab, new Vector3(0,0,0),transform.rotation); 
       Atomo.transform.parent = Elements.transform;
       Atomo.transform.position = SpanwElements.position;      
    }
    public void Molecule3D(GameObject Model) 
    {
        if (!Active3D && GetComponent<ChecarEstado>().completou)
        {
            Model.SetActive(true);
            Elements.SetActive(false);
            Active3D = true;
            btn_2D.SetActive(true);
            btn_3D.SetActive(false);
        }        
        else if (Active3D && GetComponent<ChecarEstado>().completou)
        {
            Model.SetActive(false);
            Elements.SetActive(true);
            Active3D = false;
            btn_2D.SetActive(false);
            btn_3D.SetActive(true);
        }
    }
    public void DisableObject(GameObject molde)
    {
        molde.SetActive(false);
    }
}
