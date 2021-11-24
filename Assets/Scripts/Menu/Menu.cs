using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu: MonoBehaviour
{
    public void SaveOptions()
    {
        InputField n = GetComponentInChildren<InputField>();
        PlayerPrefs.SetString("name", n.text);

        Slider s = GetComponentInChildren<Slider>();
        PlayerPrefs.SetFloat("volume", s.value);

        Toggle t = GetComponentInChildren<Toggle>();
        int subtitles = t.isOn ? 1 : 0;
        PlayerPrefs.SetInt("subtitules", subtitles);

        PlayerPrefs.Save();
    }

    public void ShowPrefs()
    {
        Debug.Log(PlayerPrefs.GetString("name"));
        Debug.Log(PlayerPrefs.GetFloat("volume"));
        Debug.Log(PlayerPrefs.GetInt("subtitules"));
    }
}
