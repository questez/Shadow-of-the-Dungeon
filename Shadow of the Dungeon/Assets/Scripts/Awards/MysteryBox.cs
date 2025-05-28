using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    [SerializeField] Animator boxAnimator;
    [SerializeField] GameObject box;
    [SerializeField] GameObject boxCrashed;
    [SerializeField] GameObject coin;
    [SerializeField] AudioSource boxCrashSound;

    Vector3 coinPosition;
    bool isCrashed = false;

    private void Start()
    {
        boxCrashed.SetActive(false);
        box.SetActive(true);
        coinPosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);

    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.CompareTag("Weapon") && !isCrashed && FindAnyObjectByType<GrabWeapon>().rb.linearVelocity.magnitude > 0.5f)
        {
            isCrashed = true;
            Instantiate(coin, coinPosition, transform.rotation);
            box.SetActive(false);
            boxCrashed.SetActive(true);
            boxAnimator.SetTrigger("Crash");      
            boxCrashSound.Play();
            Destroy(this.gameObject, boxCrashSound.clip.length);
        }
    }
}
