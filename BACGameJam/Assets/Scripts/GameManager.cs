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
	public GameObject deathScreen;
	public GameObject loadingScreen;
	public GameObject mainMenuScreen;

	//public Text waveText;

	bool gameInPlay;


	void Awake() {
        if (instance == null) {
			DontDestroyOnLoad(gameObject);
			instance = this;
			loadingScreen.SetActive(false);
		}
		else {
			Destroy(gameObject);
		}
		pauseMenuScreen.SetActive(false);
		deathScreen.SetActive(false);
    }

	public static void LoadScene (int num) {
		instance.StartCoroutine(instance.Loading(num));
	}

	IEnumerator Loading (int num) {
		loadingScreen.SetActive(true);
		AsyncOperation a = SceneManager.LoadSceneAsync(num);

		while (!a.isDone) {
			yield return new WaitForEndOfFrame();
		}

		loadingScreen.SetActive(false);
	}

	void Update() {
			Shader.SetGlobalFloat("_ZDepth", zDepth);
			Shader.SetGlobalFloat("_YOffset", yOffset);
		if (gameInPlay == true) {
			mainMenuScreen.SetActive(false);
		}
	}

	public void StartGame() {
		StartCoroutine(Loading(1));
		gameInPlay = true;
	}

	public void QuitGame() {
		Application.Quit();
	}
}
