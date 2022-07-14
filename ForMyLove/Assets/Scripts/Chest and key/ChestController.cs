using TMPro;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public bool isOpen = false;
    public bool chestCode = false;
    [SerializeField] private TextMeshProUGUI chestText;
    [SerializeField] private Animator _anim;
    [SerializeField] private AudioClip textPickup;
    [SerializeField] private AudioClip chestOpenSound;
    public void OpenChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            _anim.SetBool("open", true);
            SoundManager.instance.PlaySound(chestOpenSound);
            chestText.gameObject.SetActive(true);
            SoundManager.instance.PlaySound(textPickup);
            chestCode = true;
        }
    }
}
