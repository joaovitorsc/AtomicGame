using UnityEngine;

public class MoleculeCounter : MonoBehaviour
{
    [SerializeField] private int currentMoleculeCount = 0;

    public void IncrementAndLimit(int maxLimit)
    {
        currentMoleculeCount++;

        if (currentMoleculeCount >= maxLimit)
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetCounter()
    {
        currentMoleculeCount = 0;
    }
}