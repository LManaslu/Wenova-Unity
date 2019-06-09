using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

    public int indexResolution = 0;
    public bool full = true;
    public bool started = false;
    public string stage = "";
    public string[] characters = {"Blood", "Flesh", "Hook", "Sinker", "Trap", "Trip", "Dusk", "Dawn"};
    static public DataController instance;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else Destroy(gameObject);
    }
}
