using UnityEngine.UI;

using UnityEngine;

public class HUD : MonoBehaviour
{
    [Header("Settings")]
    public bool is3DActive = false;
    
    [Header("References")]
    public Transform spawnPoint;
    public GameObject button2D, button3D;

    private GameObject moleculeContainer;
    private CheckState stateChecker;
    void Awake()
    {
        stateChecker = GetComponent<CheckState>();
        moleculeContainer = GameObject.FindGameObjectWithTag("Molecule");
    }
    public void SpawnElement(GameObject prefab)
    {
       GameObject Atomo = Instantiate(prefab, new Vector3(0,0,0),transform.rotation); 
       Atomo.transform.parent = moleculeContainer.transform;
       Atomo.transform.position = spawnPoint.position;      
    }
    public void Toggle3DMode(GameObject model3D)
    {
        if (stateChecker == null || !stateChecker.isCompleted) return;

        is3DActive = !is3DActive;

        model3D.SetActive(is3DActive);
        moleculeContainer.SetActive(!is3DActive);

        button2D.SetActive(is3DActive);
        button3D.SetActive(!is3DActive);
    }
    public void DisableObject(GameObject target)
    {
        target.SetActive(false);
    }
}
