using UnityEngine.UI;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    void Start()
    {
        totalHealthBar.fillAmount = playerHealth._currentHealth / 10;
    }

    void Update()
    {
        currentHealthBar.fillAmount = playerHealth._currentHealth / 10;
    }
}
