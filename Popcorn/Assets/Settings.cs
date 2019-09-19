using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    GameObject panelSetting;
    public AudioMixer AudioMixer;
    public Slider sliderBGM;
    public Slider sliderSFX;
    public Toggle screen;
    public Dropdown resolution;
    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        panelSetting = this.gameObject;
        resolutions = Screen.resolutions;
        resolution.ClearOptions();

        List<string> options = new List<string>();
        int curentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                curentResolutionIndex = i;
            }
        }

        panelSetting.SetActive(false);

        resolution.AddOptions(options);
        resolution.value = curentResolutionIndex;
        resolution.RefreshShownValue();
    }
    
    public void SetVolumeBGM(float volume)
    {
        AudioMixer.SetFloat("BGM", volume);
    }
    
    public void SetVolumeSFX(float volume)
    {
        AudioMixer.SetFloat("SFX", volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void BackSetting()
    {
        panelSetting.SetActive(false);
    }
    public void OpenSetting()
    {
        panelSetting.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {

    }
}

