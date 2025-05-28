using UnityEngine;
using System.Collections;

public class SpellEffect : MonoBehaviour
{
    [SerializeField] GameObject FireballHitEffect;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FireballEffect());
    }
    IEnumerator FireballEffect()
    {
        GameObject currentEffect = Instantiate(FireballHitEffect, transform.position, transform.rotation);
        yield return new WaitForSecondsRealtime(2);
        Destroy(currentEffect);
    }
}
