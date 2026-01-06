using UnityEngine;

public class PlaceAtom : MonoBehaviour
{
    [SerializeField] private bool _isValid = true;

    public bool isValid
    {
        get => _isValid;
        set
        {
            if (_isValid != value)
            {
                _isValid = value;

                if (!_isValid)
                {
                    AudioManager.Instance?.Play("Correct");
                }

                NotifyStateChange();
            }
        }
    }

    private void NotifyStateChange()
    {
        CheckState controller = FindObjectOfType<CheckState>();
        if (controller != null)
        {
            controller.RequestStateCheck();
        }
    }
}