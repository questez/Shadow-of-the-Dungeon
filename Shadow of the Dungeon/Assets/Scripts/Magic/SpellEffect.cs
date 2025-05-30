using UnityEngine;
using System.Collections;

public class SpellEffect : MonoBehaviour
{
    [SerializeField] GameObject FireballHitEffect;
    [SerializeField] GameObject HexFireballHitEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Fireball"))
        {
            StartCoroutine(FireballEffect());
        }
        if (gameObject.CompareTag("HexFireball"))
        {
            StartCoroutine(HexFireballEffect());
        }
    }
    IEnumerator FireballEffect()
    {
        GameObject currentEffect = Instantiate(FireballHitEffect, transform.position, transform.rotation);
        yield return new WaitForSecondsRealtime(2);
        Destroy(currentEffect);
    }
    IEnumerator HexFireballEffect()
    {
        GameObject currentEffect = Instantiate(HexFireballHitEffect, transform.position, transform.rotation);
        yield return new WaitForSecondsRealtime(2);
        Destroy(currentEffect);
    }
}
