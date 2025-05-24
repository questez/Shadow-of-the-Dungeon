using UnityEngine;

public class BuySword : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] MonoBehaviour GrabInteractible;
    private int _swordPrice;
    private void Awake()
    {
        if (gameObject.name == "Sword2")
        {
            _swordPrice = 10;
        }
        if (gameObject.name == "Sword3")
        {
            _swordPrice = 100;
        }
        _button.onClick.AddListener(Buy);
        GrabInteractible.enabled = false;
    }
    public void Buy()
    {
        if (PlayerBehaviour.PlayerBalance >= _swordPrice)
        {
            _button.gameObject.SetActive(false);
            GrabInteractible.enabled = true;
            PlayerBehaviour.PlayerBalance -= _swordPrice;
        }
    }
}
