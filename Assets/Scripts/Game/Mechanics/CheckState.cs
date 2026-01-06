using UnityEngine;
using System;

public class CheckState : MonoBehaviour
{
    public static event Action OnLevelComplete;

    [Header("Status")]
    public bool isCompleted;

    [Header("UI Elements")]
    public GameObject toggle3DButton;
    public GameObject nextLevelButton;

    private GameObject[] hydrogenConnections;
    private GameObject[] carbonConnections;
    private GameObject[] linkConnections;
    private GameObject[] oxygenConnections;

    private bool isHydrogenConnected;
    private bool isCarbonConnected;
    private bool isLinkConnected;
    private bool isOxygenConnected;

    void Start()
    {
        isCompleted = false;

        hydrogenConnections = GameObject.FindGameObjectsWithTag("ConnectHidrogen");
        carbonConnections = GameObject.FindGameObjectsWithTag("ConnectCarbon");
        linkConnections = GameObject.FindGameObjectsWithTag("ConnectLink");
        oxygenConnections = GameObject.FindGameObjectsWithTag("ConnectOxygen");
    }

    public void RequestStateCheck()
    {
        if (isCompleted) return;

        CheckHydrogen();
        CheckCarbon();
        CheckLinks();
        CheckOxygen();
        ValidateCompletion();
    }

    private void CheckHydrogen()
    {
        isHydrogenConnected = IsValidGroup(hydrogenConnections);
    }

    private void CheckCarbon()
    {
        isCarbonConnected = IsValidGroup(carbonConnections);
    }

    private void CheckLinks()
    {
        isLinkConnected = IsValidGroup(linkConnections, true);
    }

    private void CheckOxygen()
    {
        isOxygenConnected = IsValidGroup(oxygenConnections);
    }

    private bool IsValidGroup(GameObject[] group, bool isLinkType = false)
    {
        foreach (GameObject obj in group)
        {
            bool isValid = isLinkType ?
                obj.GetComponent<PlaceLink>().isValid :
                obj.GetComponent<PlaceAtom>().isValid;

            if (isValid) return false;
        }
        return true;
    }

    private void ValidateCompletion()
    {
        if (isHydrogenConnected && isCarbonConnected && isLinkConnected && isOxygenConnected)
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        isCompleted = true;

        if (toggle3DButton) toggle3DButton.SetActive(true);
        if (nextLevelButton) nextLevelButton.SetActive(true);

        OnLevelComplete?.Invoke();

    }
}