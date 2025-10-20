using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [SerializeField] private GameManager gameManager;

    [Header("***Components***")]
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSource musicSource;

    [Header("***Tracks***")]
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip mainMenuMusic;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.loop = true;
        SubscribeEvents();
        if(gameManager == null)
        {
            gameManager = FindFirstObjectByType<GameManager>();
            SubscribeEvents();
        }
        CheckGameStateThenPlayMusic();
    }

    private void CheckGameStateThenPlayMusic()
    {
        
        if(gameManager.GetGameState() == GameStateEnums.MAINMENU)
        {
            Debug.LogWarning("MUSIC MANAGER MAIN MENU");
            PlayMusic(mainMenuMusic);
            SetHighPass(10f);
            SetLowPass(22000f);
        }
        if(gameManager.GetGameState() == GameStateEnums.PLAYING)
        {
            Debug.LogWarning("MUSIC MANAGER PLAYING");
            PlayMusic(gameMusic);
            SetHighPass(10f);
            SetLowPass(22000f);
        }
        if(gameManager.GetGameState() == GameStateEnums.PAUSED)
        {
            Debug.LogWarning("MUSIC MANAGER PAUSED");
            PlayMusic(gameMusic);
            SetHighPass(10f);
            SetLowPass(400f);
        }
    }

    private void SubscribeEvents()
    {
        GameManager.LinkGameManager += GetGameManager;
        GameManager.TransmitGameState += RefreshGameMusic;
    }

    private void RefreshGameMusic(GameStateEnums enums)
    {
        CheckGameStateThenPlayMusic();
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents()
    {
        GameManager.LinkGameManager -= GetGameManager;
    }
    private void GetGameManager(GameManager manager)
    {
        gameManager = manager;
    }

    private void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip) return;
        StartCoroutine(FadeMusic(clip));
    }

    private IEnumerator FadeMusic(AudioClip newClip)
    {
        float t = 0f;
        float duration = 0.7f;
        float startVol = musicSource.volume;

        // fading out old track
        while (t < duration)
        {
            t += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(startVol, t, t / duration);
            yield return null;
        }

        musicSource.clip = newClip;
        musicSource.Play();

        // fading in with new track

        t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(0, startVol, t / duration);
            yield return null;
        }
    }

    public void SetLowPass(float val)
    {
        mixer.SetFloat("LowpassCutoff", val);
    }
    public void SetHighPass(float val)
    {
        mixer.SetFloat("HighpassCutoff", val);
    }
    public void SetVolume(float val)
    {
        if (val <= 0.0001f)
        {
            mixer.SetFloat("MusicVolume", -80f);
            return;
        }
        mixer.SetFloat("MusicVolume", Mathf.Log10(val) * 20f);
    }
}
