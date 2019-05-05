using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {

    public GameObject[] stageImages;
    public Sprite[] images;
    public Text stageText;

    int maxStages, stage;
    enum Stages {Waterfalls, Mangrove, Random}
    DataController data;
    
    // Start is called before the first frame update
    void Start() {
        maxStages = stageImages.Length;
        stage = 1;
        data = FindObjectOfType<DataController>();
    }

    // Update is called once per frame
    void Update() {
        StageImage();
        if (Input.GetKeyDown(KeyCode.LeftArrow) && stage > 1) {
            stage--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && stage < maxStages) {
            stage++;
        }
    }

    void StageImage() {
        if(stage == 1) {
            stageImages[0].GetComponent<SpriteRenderer>().sprite = null;
            stageImages[1].GetComponent<SpriteRenderer>().sprite = images[0];
            stageImages[2].GetComponent<SpriteRenderer>().sprite = images[1];
            stageText.text = "Waterfalls";
        } else if(stage == 2) {
            stageImages[0].GetComponent<SpriteRenderer>().sprite = images[0];
            stageImages[1].GetComponent<SpriteRenderer>().sprite = images[1];
            stageImages[2].GetComponent<SpriteRenderer>().sprite = images[2];
            stageText.text = "Mangrove";
        } else {
            stageImages[0].GetComponent<SpriteRenderer>().sprite = images[1];
            stageImages[1].GetComponent<SpriteRenderer>().sprite = images[2];
            stageImages[2].GetComponent<SpriteRenderer>().sprite = null;
            stageText.text = "Random";
        }
    }
}
