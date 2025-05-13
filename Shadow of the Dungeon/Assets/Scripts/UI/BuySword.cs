using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class BuySword : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] MonoBehaviour GrabInteractible;
    [SerializeField] TMP_Text _coinValue;
    XROrigin _player;
    private PlayerBehaviour _pb;
    private int _swordPrice;
    public void Buy()
    {
        if (_pb.PlayerBalance >= _swordPrice)
        {
            _button.gameObject.SetActive(false);
            GrabInteractible.enabled = true;
            _pb.PlayerBalance -= _swordPrice;
            _coinValue.text = _pb.PlayerBalance.ToString();
        }
    }
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
        _player = FindAnyObjectByType<XROrigin>();
        _pb = _player.GetComponentInParent<PlayerBehaviour>();        
    }
}
