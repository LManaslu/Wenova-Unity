using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour {

    public GameObject[] positions;
    public Sprite imageNum;
    public Text charText;

    int index = 0;
    DataController data;
    Animator myAnim;
    // Start is called before the first frame update
    void Start() {
        index = 0;
        data = FindObjectOfType<DataController>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        positions[index].GetComponent<SpriteRenderer>().sprite = imageNum;
        charText.text = data.characters[index];
        myAnim.Play(data.characters[index]);
        if(Input.GetKeyDown(KeyCode.RightArrow) && index < positions.Length - 1) {
            positions[index].GetComponent<SpriteRenderer>().sprite = null;
            index++;
        } else if(Input.GetKeyDown(KeyCode.LeftArrow) && index > 0) {
            positions[index].GetComponent<SpriteRenderer>().sprite = null;
            index--;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && index > 1) {
            positions[index].GetComponent<SpriteRenderer>().sprite = null;
            index -= 2;
        } else if(Input.GetKeyDown(KeyCode.DownArrow) && index < positions.Length - 2) {
            positions[index].GetComponent<SpriteRenderer>().sprite = null;
            index += 2;
        }
    }
}
