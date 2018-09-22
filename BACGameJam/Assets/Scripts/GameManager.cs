using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public static GameManager register;

	public GameObject pauseMenuScreen;
	public GameObject deathScreen;
	public GameObject loadingScreen;
	public Slider loadingBar;

	public Text waveText;

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
			loadingBar.value = a.progress;
			yield return new WaitForEndOfFrame();
		}

		loadingScreen.SetActive(false);
	}

	void Update() {
		
	}

	public void StartGame() {
		StartCoroutine(Loading(1));
	}
}
