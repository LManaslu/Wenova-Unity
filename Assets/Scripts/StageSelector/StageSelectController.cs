using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectController : MonoBehaviour {

    public GameObject[] stageImages;
    public Sprite[] images;
    public AudioClip[] soundsEffects;
    public Text stageText;

    int maxStages, stage;
    enum Stages {Waterfalls, Mangrove, Random}
    DataController data;

    // Start is called before the first frame update
    void Start() {
        maxStages = stageImages.Length;
        stage = 1;
        data = FindObjectOfType<DataController>();
        Debug.Log(data.stage);
    }

    // Update is called once per frame
    void Update() {
        StageImage();
        if(Input.GetKeyDown(KeyCode.Escape)) {
            AudioSource.PlayClipAtPoint(soundsEffects[2], transform.position);
            StartCoroutine(DelayLoadScene("Menu"));
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && stage > 1) {
            AudioSource.PlayClipAtPoint(soundsEffects[0], transform.position);
            stage--;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && stage < maxStages) {
            AudioSource.PlayClipAtPoint(soundsEffects[0], transform.position);
            stage++;
        }
        if(Input.GetKeyDown(KeyCode.Return)) {
            string selected = System.Enum.GetName(typeof(Stages), stage - 1);
            if(selected == "Random") {
                string[] stgs = {"Waterfalls", "Mangrove"};
                int id = Random.Range(0, maxStages - 1);
                data.stage = stgs[id];
            } else {
                data.stage = selected;
            }
            AudioSource.PlayClipAtPoint(soundsEffects[1], transform.position);
            StartCoroutine(DelayLoadScene("CharacterSelector"));
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

    IEnumerator DelayLoadScene(string sceneName) {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneName);
    }
}
