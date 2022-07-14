using UnityEngine;

public class Baloons : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    void Start()
    {
        _anim.SetBool("baloons", true);
    }
}
