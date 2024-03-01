using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public GameObject player;
    public GameObject menuScreen;
    public bool startPaused;
    public bool Busy = false;

    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    public bool inverted = false;
    public float mouseSensitivity = 10f;
    
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        if (startPaused)
             Pause();
    }
    
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;

        if (!menuScreen.activeSelf)
            Pause();
        else
            Play();
    }
    
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        menuScreen.SetActive(true);
        Time.timeScale = 0;
        Busy = true;
    }
    
    public void Play()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menuScreen.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<ToggleTheThing>().ContinueToggle();
        menuScreen.SetActive(false);
        Time.timeScale = 1;
        Busy = false;
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Luca's House");
    }

    // Settings
    public void SetMusicVolume(float volume)
    {
        player.transform.GetChild(0).GetComponent<AudioSource>().volume = volume;
    }

    public void SetSensitivity(float sensitivity)
    {
        mouseSensitivity = sensitivity * 1000f;
    }
    
    public void SetInvert(bool isInverted)
    {
        inverted = isInverted;
    }
    
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}