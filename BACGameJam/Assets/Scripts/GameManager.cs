using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour {

	public float zDepth = 0.5f;
	public float yOffset = 1;
	public static GameManager instance;
	public static GameManager register;

	public GameObject pauseMenuScreen;

	public Text waveText;

	bool gameInPlay;


	void Awake() {
        if (instance == null) {
            instance = this;
        }
				if (pauseMenuScreen != null) {
					pauseMenuScreen.SetActive(false);
				}
  }

	void Update() {
			Shader.SetGlobalFloat("_ZDepth", zDepth);
			Shader.SetGlobalFloat("_YOffset", yOffset);
	}
}
