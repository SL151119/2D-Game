using UnityEngine.Events;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int keycount;
    public int coinCount;
    public bool coinCode = false;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private AudioClip coinPickup;
    [SerializeField] private AudioClip textPickup;
    [SerializeField] private ForThirdNumber number;
    [SerializeField] private ChestController chest;
    [SerializeField] private Finish finish;

    private void Start()
    {
        keycount = 0;
        coinCount = 0;
        number.thirdnumberCode = false;
        chest.chestCode = false;
        coinCode = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Chest"))
        {
            if (keycount > 0 && !chest.isOpen)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    chest.OpenChest();
                    keycount--;
                }
            }
        }

        if (other.CompareTag("Third"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                number.TakeNumber();
            }
        }

        if (other.CompareTag("Finish"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (chest.chestCode && coinCode && number.thirdnumberCode)
                {
                    finish.EndGame();
                }
                else
                {
                    finish.NoCode();
                }
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coinCount++;
            SoundManager.instance.PlaySound(coinPickup);
            Destroy(collision.gameObject);
            CheckCoin();
        }
    }

    public void CheckCoin()
    {
        if (coinCount == 7)
        {
            coinText.gameObject.SetActive(true);
            SoundManager.instance.PlaySound(textPickup);
            coinCode = true;
        }
        else
        {
            coinCode = false;
        }
    }
}
