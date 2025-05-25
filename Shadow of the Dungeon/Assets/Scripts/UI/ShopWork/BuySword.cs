using UnityEngine;
using UnityEngine.UI;

public class BuySword : MonoBehaviour
{
    [SerializeField] AudioSource _clickSound;
    [SerializeField] Button buySwordButton;
    [SerializeField] Button putOnButton;
    [SerializeField] MonoBehaviour GrabInteractible;
    private PlayerBehaviour _pb;
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
        buySwordButton.onClick.AddListener(BuyWeapon);
        GrabInteractible.enabled = false;
        _pb = FindAnyObjectByType<PlayerBehaviour>();
        buySwordButton.gameObject.SetActive(true);
        putOnButton.gameObject.SetActive(false);
    }
    public void BuyWeapon()
    {        
        if (PlayerBehaviour.PlayerBalance >= _swordPrice)
        {
            _clickSound.Play();
            buySwordButton.gameObject.SetActive(false);
            putOnButton.gameObject.SetActive(true);
            //GrabInteractible.enabled = true;
            PlayerBehaviour.PlayerBalance -= _swordPrice;
            _pb.CoinValue.text = PlayerBehaviour.PlayerBalance.ToString();
        }
    }    
}
