using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpController : MonoBehaviour {

    public AudioClip soundEffect;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            StartCoroutine(CancelAction());
        }
    }

    IEnumerator CancelAction() {
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Options");
    }
}
