using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public static GameManager register;

	public GameObject pauseMenuScreen;

	public Text waveText;

	bool gameInPlay;


	void Awake() {
        if (instance == null) {
            instance = this;
        }
		pauseMenuScreen.SetActive(false);
    }

	void Update() {
		
	}
}
