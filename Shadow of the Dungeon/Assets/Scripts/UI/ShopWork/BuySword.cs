using UnityEngine;
using UnityEngine.UI;

public class BuySword : MonoBehaviour
{
    [SerializeField] GameObject sword;
    [SerializeField] AudioSource _clickSound;
    [SerializeField] Button buySwordButton;
    [SerializeField] Button putOnButton;

    [SerializeField] MonoBehaviour GrabInteractible;
    PlayerBehaviour _pb;
    int _swordPrice;

    public static int[] isPurchased = { 1, 0, 0 };

    private void Awake()
    {
        buySwordButton.onClick.AddListener(BuyWeapon);

        SavingSystem.LoadShop();
        
        GrabInteractible.enabled = false;
        _pb = FindAnyObjectByType<PlayerBehaviour>();

        buySwordButton.gameObject.SetActive(true);
        putOnButton.gameObject.SetActive(false);
    }

    private void Start()
    {
        CheckSwordCondition();
    }

    private void CheckSwordCondition()
    {
        if (sword.name == "Sword2" && isPurchased[1] == 1)
        {
            buySwordButton.gameObject.SetActive(false);
            putOnButton.gameObject.SetActive(true);
        }
        if (sword.name == "Sword3" && isPurchased[2] == 1)
        {
            buySwordButton.gameObject.SetActive(false);
            putOnButton.gameObject.SetActive(true);
        }

        if (sword.name == "Sword2" && isPurchased[1] == 0)
        {
            _swordPrice = 10;
        }
        if (sword.name == "Sword3" && isPurchased[2] == 0)
        {
            _swordPrice = 20;
        }

    }

    public void BuyWeapon()
    {        
        if (PlayerBehaviour.PlayerBalance >= _swordPrice)
        {
            _clickSound.Play();
            buySwordButton.gameObject.SetActive(false);
            putOnButton.gameObject.SetActive(true);
            PlayerBehaviour.PlayerBalance -= _swordPrice;
            if (sword.name == "Sword2") isPurchased[1] = 1;
            if (sword.name == "Sword3") isPurchased[2] = 1;

            SavingSystem.SaveShop();
        }
    }    
}
