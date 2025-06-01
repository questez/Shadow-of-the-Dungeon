using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabWeapon : MonoBehaviour
{
    GameObject musicSource;
    AudioSource musicInLevel;

    [NonSerialized] public Rigidbody rb;

    [SerializeField] Collider weaponCollider;

    GameObject stone_pillar;
    Collider _stonetableCollider;

    [SerializeField] GameObject _canvas;

    GameObject enemySpawner;

    public float PlayerDamage;

    bool islevelStarted = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        stone_pillar = GameObject.Find("stone_pillar");
        _stonetableCollider = stone_pillar.GetComponent<Collider>();
        musicSource = GameObject.FindGameObjectWithTag("MusicSource");
        if (musicSource != null)
        {
            musicInLevel = musicSource.GetComponent<AudioSource>();
            //musicInLevel.volume = ChangeSliderValue.MusicValue;
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

    public bool HitTrack { get => rb.linearVelocity.magnitude >= 0.5f; }    
}