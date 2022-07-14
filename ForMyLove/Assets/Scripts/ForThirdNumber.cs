using UnityEngine;
using TMPro;

public class ForThirdNumber : MonoBehaviour
{
    public bool thirdnumberCode;
    [SerializeField] private AudioClip textPickup;
    [SerializeField] private TextMeshProUGUI thirdText;

    public void TakeNumber()
    {
        thirdText.gameObject.SetActive(true);
        SoundManager.instance.PlaySound(textPickup);
        thirdnumberCode = true;
        Destroy(gameObject);
    }
}
