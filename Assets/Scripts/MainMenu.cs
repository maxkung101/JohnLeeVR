﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int id;

    public void PlayGame()
    {
        PlayerPrefs.SetInt("John Lee VR - Player Id", id);
        SceneManager.LoadScene("SampleScene");
    }
}
