﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public bool isStart;
	public bool isQuit;

	void onMouseUp()
	{
		if (isStart)
		{
			Application.LoadLevel(1);
		}
		if(isQuit)
		{
			Application.Quit();
		}

	}
}
