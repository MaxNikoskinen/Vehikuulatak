using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public static bool isCutsceneOn;
    public Animator camAnim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            camAnim.SetBool("cutscene1", true);
            isCutsceneOn = true;
            Invoke(nameof(StopCutScene), 3f);
        }
    }

    void StopCutScene()
    {
        isCutsceneOn = false;
        camAnim.SetBool("cutsscene1", false);
    }

}
