﻿/*
 * 
 * 
 * Copyright (c) 2017 Gento Morikawa
 * Released under the MIT license
 * 
 * 
 * 
 * 
*/
using System;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	public static T Instance {
		get {
			if (instance == null) {
				Type t = typeof(T);

				instance = (T)FindObjectOfType (t);
				if (instance == null) {
					Debug.LogError ("There is no GameObject that attaches" + t);
				}
			}

			return instance;
		}
	}

	virtual protected void Awake ()
	{
		if (this != Instance) {
			Destroy (this);
			return;
		}

		//DontDestroyOnLoad(this.gameObject);
	}

}