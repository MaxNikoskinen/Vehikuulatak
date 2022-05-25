using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
        GameManager.Instance.Money += 1000;
        PlayerPrefs.SetInt("money", GameManager.Instance.Money);
        UIManager.Instance.UpdateMoneyText(GameManager.Instance.Money);
    }
}
