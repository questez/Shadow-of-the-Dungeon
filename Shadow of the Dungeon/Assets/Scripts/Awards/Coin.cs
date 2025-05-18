using TMPro;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Coin : MonoBehaviour
{
    PlayerBehaviour pb;
    float _rotationSpeed = 300f;
    TMP_Text CoinValue;

    [SerializeField] AudioSource _coinSound;

    private void Awake()
    {
        pb = FindAnyObjectByType<XROrigin>().GetComponent<PlayerBehaviour>();
        CoinValue = GameObject.Find("CoinValue").GetComponent<TMP_Text>();
    }

    //private void Start()
    //{
    //    ChangeSliderValue soundvalue = gameObject.AddComponent<ChangeSliderValue>();
    //    _coinSound.volume = soundvalue.SoundValue;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {            
            pb.PlayerBalance++;
            _coinSound.Play();
            Destroy(this.gameObject, _coinSound.clip.length);            
            Debug.Log($"Собрана монетка! Текущее количество: {pb.PlayerBalance}.");
            CoinValue.text = pb.PlayerBalance.ToString();
        }
    }

    private void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);        
    }
}
