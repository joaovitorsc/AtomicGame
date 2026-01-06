using UnityEngine;

public class RotateMolecule : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 0.2f;

    private Touch touch;
    private Quaternion rotationY;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float rotationAmount = touch.deltaPosition.x * rotationSpeed;
                rotationY = Quaternion.Euler(0f, -rotationAmount, 0f);

                transform.rotation = rotationY * transform.rotation;
            }
        }
    }
    public void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }
}