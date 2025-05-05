using UnityEngine;

public class BuySword : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] MonoBehaviour GrabInteractible;
    public void Buy()
    {
        Debug.Log("Bought a new sword");
        _button.gameObject.SetActive(false);
        GrabInteractible.enabled = true;
    }
    private void Awake()
    {
        _button.onClick.AddListener(Buy);
        GrabInteractible.enabled = false;
    }
}
