using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

    public Text[] optionsTexts;
    public Text resolutionText;
    public Text fullscreenText;
    public AudioClip[] soundsEffects;

    int index;
    int resolutionIndex = 0;
    bool full = true;
    string[] resolutions = {"1920 x 1080", "1280 x 720", "800 x 600"};
    enum Options {Resolution, Fullscreen, Keyboard, Joystick, Back};
    [SerializeField] Vector2[] resol;

    // Start is called before the first frame update
    void Start() {
        index = 0;
    }

    // Update is called once per frame
    void Update() {
        optionsTexts[index].color = new Color(181f / 255f, 201f / 255, 60f / 255f);
        resolutionText.text = resolutions[resolutionIndex];
        fullscreenText.text = full ? "On" : "Off";
        Screen.SetResolution((int)resol[resolutionIndex].x, (int)resol[resolutionIndex].y, full);
        if(Input.GetKeyDown(KeyCode.Escape)) {
            AudioSource.PlayClipAtPoint(soundsEffects[2], transform.position);
            StartCoroutine(DelayLoadScene("Menu"));
        }else if(Input.GetKeyDown(KeyCode.DownArrow) && index < optionsTexts.Length - 1) {
            AudioSource.PlayClipAtPoint(soundsEffects[0], transform.position);
            optionsTexts[index].color = Color.white;
            index++;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && index > 0) {
            AudioSource.PlayClipAtPoint(soundsEffects[0], transform.position);
            optionsTexts[index].color = Color.white;
            index--;
        } else if(Input.GetKeyDown(KeyCode.Return)) {
            AudioSource.PlayClipAtPoint(soundsEffects[1], transform.position);
            string selected = System.Enum.GetName(typeof(Options), index);
            if(selected == "Back") StartCoroutine(DelayLoadScene("Menu"));
            else if(selected == "Fullscreen") full = !full;
            else if(selected == "Resolution") {
                resolutionIndex++;
                if(resolutionIndex > resolutions.Length - 1) resolutionIndex = 0;
            } else StartCoroutine(DelayLoadScene(selected));
        }
    }

    IEnumerator DelayLoadScene(string sceneName) {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneName);
    }
}
