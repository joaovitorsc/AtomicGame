using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveCarbon : MonoBehaviour
{
    [Header("Movement Settings")]
    [Range(1, 15)] public float moveSpeed = 10f;
    [Range(0.1f, 2.0f)] public float minConnectDistance = 0.5f;

    [Header("Status")]
    public bool isConnected;

    private Rigidbody rb3D;
    private Camera mainCamera;
    private Vector3 startOffset;
    private bool isHolding;
    private GameObject[] connectionPoints;
    private PlaceAtom currentOccupiedPoint;

    void Start()
    {
        rb3D = GetComponent<Rigidbody>();
        mainCamera = Camera.main;

        connectionPoints = GameObject.FindGameObjectsWithTag("ConnectCarbon");
    }

    void OnMouseDown()
    {
        startOffset = transform.position - GetMouseWorldPosition();
        isHolding = true;

        if (isConnected)
        {
            Disconnect();
        }
    }

    void OnMouseDrag()
    {
        Vector3 targetPos = startOffset + GetMouseWorldPosition();
        Vector3 direction = targetPos - transform.position;
        rb3D.velocity = direction * moveSpeed;
    }

    void OnMouseUp()
    {
        isHolding = false;
        rb3D.velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        if (!isHolding && !isConnected)
        {
            HandleSnapping();
        }
    }

    private void HandleSnapping()
    {
        foreach (GameObject point in connectionPoints)
        {
            PlaceAtom atomPoint = point.GetComponent<PlaceAtom>();

            if (!atomPoint.isValid) continue;

            float distance = Vector3.Distance(transform.position, point.transform.position);

            if (distance < minConnectDistance)
            {
                rb3D.velocity = Vector3.zero;
                transform.position = Vector3.MoveTowards(transform.position, point.transform.position, 0.05f);
            }

            if (distance < 0.01f)
            {
                Connect(atomPoint);
                break;
            }
        }
    }

    private void Connect(PlaceAtom atomPoint)
    {
        isConnected = true;
        currentOccupiedPoint = atomPoint;
        transform.position = atomPoint.transform.position;

        atomPoint.isValid = false;
    }

    private void Disconnect()
    {
        isConnected = false;

        if (currentOccupiedPoint != null)
        {
            currentOccupiedPoint.isValid = true; 
            currentOccupiedPoint = null;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}