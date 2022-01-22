using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Sound Effect")]
public class SoundEffect : ScriptableObject
{
    public AudioClip[] clips;

    [MinMaxSlider(0f, 1f)]
    public Vector2 volume = new Vector2(1, 1);

    [MinMaxSlider(0f, 2f)]
    public Vector2 pitch = new Vector2(1, 1);

    // Play using the default sound effect source
    public void Play()
    {
        Play(AudioManager.instance.GetSoundEffectSource());
    }

    public void Play(AudioSource source)
    {
        if (clips.Length == 0)
        {
            return;
        }

        source.clip = clips[Random.Range(0, clips.Length)];
        source.spatialBlend = 0;
        source.volume = Random.Range(volume.x, volume.y);
        source.pitch = Random.Range(pitch.x, pitch.y);
        source.Play();
    }
}
