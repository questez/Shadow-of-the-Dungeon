using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabWeapon : MonoBehaviour
{
    GameObject musicSource;
    AudioSource musicInLevel;

    [SerializeField] Collider weaponCollider; // коллайдер оружия
    [SerializeField] Collider _stonetableCollider; // коллайдер стола, на котором лежит меч в начале уровня
    [SerializeField] GameObject _canvas;

    GameObject enemySpawner;

    public float PlayerDamage; // добавить чтобы с увеличением скорости урон также увеличивался    

    bool islevelStarted = false;

    private void Start()
    {
        musicSource = GameObject.FindGameObjectWithTag("MusicSource");
        if (musicSource != null)
        {
            musicInLevel = musicSource.GetComponent<AudioSource>();
        }        
        enemySpawner = GameObject.Find("EnemySpawnManager");
        if (enemySpawner != null)
        {
            enemySpawner.SetActive(false);
        }               
    }

    public void OnGrab(SelectEnterEventArgs args)
    {
        if (_canvas != null)
        {
            _canvas.SetActive(true);
        }
        if (weaponCollider != null)
        {
            weaponCollider.isTrigger = true;
        }
        if (_stonetableCollider != null && enemySpawner != null && !islevelStarted)
        {
            musicInLevel.Play();
            _stonetableCollider.attachedRigidbody.isKinematic = false;
            _stonetableCollider.isTrigger = true;
            enemySpawner.SetActive(true);
            islevelStarted = true;            
        }
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
    }
    public void OnUnGrab(SelectExitEventArgs args)
    {
        
        if (weaponCollider != null)
        {
            weaponCollider.isTrigger = false;
        }
               
        args.interactableObject.transform.SetParent(null);
    }
}
