using UnityEngine;

public class BuySword : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    public void Buy()
    {
        Debug.Log("Bought a new sword");
        _button.gameObject.SetActive(false);
    }
    private void Awake()
    {
        _button.onClick.AddListener(Buy);
    }
}
