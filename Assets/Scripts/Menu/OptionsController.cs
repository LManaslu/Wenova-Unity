using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

    public Text[] optionsTexts;
    public Text resolutionText;
    public Text fullscreenText;

    int index;
    int resolutionIndex;
    string[] resolutions = {"1920 x 1080", "1280 x 720", "800 x 600"};

    // Start is called before the first frame update
    void Start() {
        index = 0;
        Debug.Log(Screen.currentResolution);    
    }

    // Update is called once per frame
    void Update() {
        
    }
}
