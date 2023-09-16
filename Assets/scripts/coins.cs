
using UnityEngine;


public class coins : MonoBehaviour
{
    private GameObject player;
    private AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSource.PlayOneShot(audioClip);
            Destroy(gameObject);
        }
    }
}
