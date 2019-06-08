using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour {

    public Text timeText;
    public float time = 30f;

    // Start is called before the first frame update
    void Start() {
        SoundController.PlayLevelMusic(0);
    }

    // Update is called once per frame
    void Update() {
        time -= Time.deltaTime;
        int timeInt = (int)time;
        timeText.text = "" + timeInt.ToString();
    }
}
