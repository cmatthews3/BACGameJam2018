﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	public static UIController instance;

	void Awake() {
        if (instance == null) {
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
		else {
			Destroy(gameObject);
		}
    }
}
