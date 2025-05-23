using UnityEngine;

public class BuySword : MonoBehaviour
{
    [SerializeField] AudioSource _clickSound;
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] MonoBehaviour GrabInteractible;
    private PlayerBehaviour _pb;
    private int _swordPrice;
    public void Buy()
    {
        _clickSound.Play();
        if (_pb.PlayerBalance >= _swordPrice)
        {
            _button.gameObject.SetActive(false);
            GrabInteractible.enabled = true;
            _pb.PlayerBalance -= _swordPrice;
            _pb.CoinValue.text = _pb.PlayerBalance.ToString();
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
        _pb = FindAnyObjectByType<PlayerBehaviour>();
    }
}
