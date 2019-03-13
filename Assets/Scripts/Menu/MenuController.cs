using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public Text[] statesText;
    public AudioClip[] soundsEffects;

    int state;
    int maxStates;
    enum StateSelect {StageSelect, Options, Exit};

    void Start() {
        state = 1;
        maxStates = statesText.Length;
        SoundController.PlayMenuMusic();
    }

    void Update() {
        ShowState();
        if(Input.GetKeyDown(KeyCode.LeftArrow) && state > 1) {
            state--;
            AudioSource.PlayClipAtPoint(soundsEffects[0], transform.position);
        } else if(Input.GetKeyDown(KeyCode.RightArrow) && state < maxStates) {
            state++;
            AudioSource.PlayClipAtPoint(soundsEffects[0], transform.position);
        }
        if(Input.GetKeyDown(KeyCode.Return)) {
            AudioSource.PlayClipAtPoint(soundsEffects[1], transform.position);
            string selected = System.Enum.GetName(typeof(StateSelect), state - 1);
            if (selected == "Exit") Application.Quit();
            else StartCoroutine(DelayLoadScene(selected));
        }
    }

    void ShowState() {
        if(state == 1) {
            statesText[0].text = "";
            statesText[1].text = "Start";
            statesText[2].text = "Options";
        } else if(state == 2) {
            statesText[0].text = "Start";
            statesText[1].text = "Options";
            statesText[2].text = "Exit";
        } else {
            statesText[0].text = "Options";
            statesText[1].text = "Exit";
            statesText[2].text = "";
        }
    }

    IEnumerator DelayLoadScene(string sceneName) {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneName);
    }
}
