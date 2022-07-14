using UnityEngine;

public class FireballHolder : MonoBehaviour
{
    [SerializeField] private Transform enemy;

    void Update()
    {
        transform.localScale = enemy.localScale;   
    }
}
