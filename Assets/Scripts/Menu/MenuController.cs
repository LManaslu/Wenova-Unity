using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public Text[] statesText;

    int state;
    int maxStates;
    enum StateSelect {StageSelect, Options, Exit};

    void Start() {
        state = 1;
        maxStates = statesText.Length;
    }

    void Update() {
        ShowState();
        if(Input.GetKeyDown(KeyCode.LeftArrow) && state > 1) {
            state--;
        } else if(Input.GetKeyDown(KeyCode.RightArrow) && state < maxStates) {
            state++;
        }
        if(Input.GetKeyDown(KeyCode.Return)) {
            string selected = System.Enum.GetName(typeof(StateSelect), state - 1);
            if (selected == "Exit") Application.Quit();
            else SceneManager.LoadScene(selected);
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
}
