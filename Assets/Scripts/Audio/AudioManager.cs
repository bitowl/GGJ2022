using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager instance { get { return _instance; } }

    [Header("Sound Effects")]
    public FloatVar sfxVolume;
    public AudioMixer sfxAudioMixer;
    public string masterSfxVolumeParamName = "masterSfxVolume";
    [Tooltip("How many audio sources should be created at the start.")]
    public int prewarmCount = 10;

    public AudioMixerGroup soundEffectMixerGroup;

    [Header("Music")]
    public FloatVar musicVolume;
    public string masterMusicVolumeParamName = "masterMusicVolume";
    public AudioMixer musicAudioMixer;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            PrewarmSoundEffects(prewarmCount);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        sfxAudioMixer.SetFloat(masterSfxVolumeParamName, Mathf.Log10(sfxVolume.value + 0.00001f) * 20);
        musicAudioMixer.SetFloat(masterMusicVolumeParamName, Mathf.Log10(musicVolume.value + 0.00001f) * 20);
    }

    // Pool for audio sources for sound effects.
    private Queue<AudioSource> audioSourcePool = new Queue<AudioSource>();
    private LinkedList<AudioSource> inUseAudioSources = new LinkedList<AudioSource>();
    private int lastCheckFrame = -1;

    /// <summary>
    /// Returns an audio source for an unpositioned sound effect to play.
    /// </summary>
    public AudioSource GetSoundEffectSource()
    {
        // Check usage only once 
        if (lastCheckFrame != Time.frameCount)
        {
            lastCheckFrame = Time.frameCount;
            CheckInUse();
        }

        AudioSource audioSource;
        if (audioSourcePool.Count == 0)
        {
            audioSource = CreateAudioSource();
        }
        else
        {
            audioSource = audioSourcePool.Dequeue();
        }

        inUseAudioSources.AddLast(audioSource);

        audioSource.gameObject.SetActive(true);

        return audioSource;
    }

    private AudioSource CreateAudioSource()
    {
        var go = new GameObject();
        go.name = "Audio Source (pooled)";
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.spatialBlend = 0;
        audioSource.outputAudioMixerGroup = soundEffectMixerGroup;
        go.SetActive(false);
        go.transform.SetParent(transform);
        return audioSource;
    }

    private void CheckInUse()
    {
        var node = inUseAudioSources.First;
        while (node != null)
        {
            if (!IsActive(node.Value))
            {
                node.Value.gameObject.SetActive(false);
                audioSourcePool.Enqueue(node.Value);
                inUseAudioSources.Remove(node);
            }
            node = node.Next;
        }
    }

    private bool IsActive(AudioSource audioSource)
    {
        return audioSource.isPlaying;
    }

    private void PrewarmSoundEffects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            audioSourcePool.Enqueue(CreateAudioSource());
        }
    }

    public void PlaySoundEffect(SoundEffect soundEffect)
    {
        soundEffect.Play(GetSoundEffectSource());
    }

}
