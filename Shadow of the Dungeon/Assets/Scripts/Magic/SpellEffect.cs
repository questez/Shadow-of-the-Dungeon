using UnityEngine;

public class SpellEffect : MonoBehaviour
{
    [SerializeField] GameObject FireballHitEffect;
    private void OnTriggerEnter(Collider other)
    {
        GameObject currentEffect = Instantiate(FireballHitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
