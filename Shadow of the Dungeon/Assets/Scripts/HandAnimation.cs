using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

public class HandAnimation : MonoBehaviour
{
    [SerializeField] private XRInputValueReader<float> _triggerInput;
    [SerializeField] private XRInputValueReader<float> _gripInput;
    [SerializeField] private Animator _handAnimator;

    private void Update()
    {
        // считываем действия с контроллеров для работы анимации рук:
        _handAnimator.SetFloat("Trigger", _triggerInput.ReadValue()); 
        _handAnimator.SetFloat("Grip", _gripInput.ReadValue());
    }
}
