using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {

    public Text timeText;
    public float time = 30f;
    public int stageSound;

    // Start is called before the first frame update
    void Start() {
        SoundController.PlayLevelMusic(stageSound);
    }

    // Update is called once per frame
    void Update() {
        time -= Time.deltaTime;
        int timeInt = (int)time;
        timeText.text = "" + timeInt.ToString();
        if(Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Menu");
        }
    }
}
