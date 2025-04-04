using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

public class HandAnimation : MonoBehaviour
{
    [SerializeField]
    XRInputValueReader<float> m_TriggerInput;
    [SerializeField]
    XRInputValueReader<float> m_GripInput;

    [SerializeField] Animator _handAnimator;

    private void Update()
    {
        // считываем действия с контроллеров для работы анимации рук:
        _handAnimator.SetFloat("Trigger", m_TriggerInput.ReadValue()); 
        _handAnimator.SetFloat("Grip", m_GripInput.ReadValue());
    }
}
