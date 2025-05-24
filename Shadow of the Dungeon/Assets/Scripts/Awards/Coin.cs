using UnityEngine;

public class Coin : MonoBehaviour
{
    float _rotationSpeed = 300f;
    

    [SerializeField] AudioSource _coinSound;    

    //private void Start()
    //{
    //    ChangeSliderValue soundvalue = gameObject.AddComponent<ChangeSliderValue>();
    //    _coinSound.volume = soundvalue.SoundValue;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour.PlayerBalance++;
            _coinSound.Play();
            Destroy(this.gameObject, _coinSound.clip.length);            
            Debug.Log($"Собрана монетка! Текущее количество: {PlayerBehaviour.PlayerBalance}.");
        }
    }

    private void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);        
    }
}
