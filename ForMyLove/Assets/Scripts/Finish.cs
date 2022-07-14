using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioClip endGameSound;
    [SerializeField] private AudioClip noCodeSound;
    [SerializeField] private Animator _anim;
    public void EndGame()
    {
        _anim.SetBool("win", true);
        SoundManager.instance.PlaySound(endGameSound);
        StartCoroutine("BubikWin");
    }

    public void NoCode()
    {
        SoundManager.instance.PlaySound(noCodeSound);
    }

    public IEnumerator BubikWin ()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("WinMenu");
    }
}
