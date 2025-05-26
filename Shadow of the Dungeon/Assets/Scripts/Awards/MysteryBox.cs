using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    [SerializeField] Animator boxAnimator;
    [SerializeField] GameObject box;
    [SerializeField] GameObject boxCrashed;
    [SerializeField] GameObject coin;
    System.Random rand = new System.Random();
    [SerializeField] AudioSource boxCrashSound;

    Vector3 coinPosition1, coinPosition2, coinPosition3;
    bool isCrashed = false;

    private void Start()
    {
        boxCrashed.SetActive(false);
        box.SetActive(true);
        coinPosition1 = new Vector3(transform.position.x - 0.8f, transform.position.y + 1f, transform.position.z);
        coinPosition2 = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        coinPosition3 = new Vector3(transform.position.x - 0.4f, transform.position.y + 1f, transform.position.z - 0.35f);
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.CompareTag("Weapon") && !isCrashed && FindAnyObjectByType<GrabWeapon>().HitTrack)
        {
            isCrashed = true;
            Instantiate(coin, coinPosition1, transform.rotation);
            Instantiate(coin, coinPosition2, transform.rotation);
            Instantiate(coin, coinPosition3, transform.rotation);
            box.SetActive(false);
            boxCrashed.SetActive(true);
            boxAnimator.SetTrigger("Crash");      
            boxCrashSound.Play();
            Destroy(this.gameObject, boxCrashSound.clip.length);
        }
    }
}
