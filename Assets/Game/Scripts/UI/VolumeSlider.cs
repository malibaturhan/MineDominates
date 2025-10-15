using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [Header("***Elements***")]
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string parameterName = "MusicVolume"; // exposed parameter in mixer
    [SerializeField] private Slider slider;
    [SerializeField] private bool saveToPrefs = true;

    private const string PlayerPrefKeyPrefix = "Volume_";

    private void Awake()
    {
        if(slider is null)
        {
            slider = GetComponent<Slider>();
        }
    }
    void Start()
    {
        if (saveToPrefs && PlayerPrefs.HasKey(PlayerPrefKeyPrefix + parameterName)) 
        {
            float savedValue = PlayerPrefs.GetFloat(PlayerPrefKeyPrefix + parameterName);
            slider.value = savedValue;
            SetVolume(savedValue);
        }
        else
        {
            slider.value = 1f;
            SetVolume(1f);
        }
        slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(SetVolume);
    }

    public void SetVolume(float val)
    {
        if(val < 0.001f)
        {
            mixer.SetFloat(PlayerPrefKeyPrefix + parameterName, -80f); // min val for volume
        }
        else
        {
            float db = Mathf.Log10(val) * 20;
            mixer.SetFloat(parameterName, db);
        }
        if (saveToPrefs)
        {
            PlayerPrefs.SetFloat(PlayerPrefKeyPrefix + parameterName, val);
        }
    }

}
