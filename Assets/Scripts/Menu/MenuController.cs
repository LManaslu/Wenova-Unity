using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public Text[] statesText;
    public Text startText;
    public AudioClip[] soundsEffects;

    int state;
    int maxStates;
    enum StateSelect {StageSelector, Options, Exit};
    DataController data;

    void Start() {
        state = 1;
        data = FindObjectOfType<DataController>();
        maxStates = statesText.Length;
        SoundController.PlayMenuMusic();
    }

    void Update() {
        IsStarted();
        if(data.started) ShowState();
        if(Input.GetKeyDown(KeyCode.Escape) && data.started) {
            AudioSource.PlayClipAtPoint(soundsEffects[2], transform.position);
            data.started = false;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow) && state > 1 && data.started) {
            state--;
            AudioSource.PlayClipAtPoint(soundsEffects[0], transform.position);
        } else if(Input.GetKeyDown(KeyCode.RightArrow) && state < maxStates && data.started) {
            state++;
            AudioSource.PlayClipAtPoint(soundsEffects[0], transform.position);
        }
        if(Input.GetKeyDown(KeyCode.Return)) {
            if (!data.started) data.started = true;
            else {
                AudioSource.PlayClipAtPoint(soundsEffects[1], transform.position);
                string selected = System.Enum.GetName(typeof(StateSelect), state - 1);
                if (selected == "Exit") Application.Quit();
                else StartCoroutine(DelayLoadScene(selected));
            }
        }
    }

    void ShowState() {
        if(state == 1) {
            statesText[0].text = "";
            statesText[1].text = "Play";
            statesText[2].text = "Options";
        } else if(state == 2) {
            statesText[0].text = "Play";
            statesText[1].text = "Options";
            statesText[2].text = "Exit";
        } else {
            statesText[0].text = "Options";
            statesText[1].text = "Exit";
            statesText[2].text = "";
        }
    }

    void IsStarted() {
        if(data.started) {
            for(int i = 0; i < maxStates; i++) {
                statesText[i].gameObject.SetActive(true);
                startText.gameObject.SetActive(false);
            }
        } else {
            for (int i = 0; i < maxStates; i++) {
                statesText[i].gameObject.SetActive(false);
                startText.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator DelayLoadScene(string sceneName) {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneName);
    }
}
