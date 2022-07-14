using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private AudioClip keyPickup;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUp();
        }
    }
    public void PickUp()
    {
        playerManager.keycount++;
        SoundManager.instance.PlaySound(keyPickup);
        Destroy(gameObject);
    }
}

