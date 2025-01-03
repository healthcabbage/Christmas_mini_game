using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSystem : MonoBehaviour
{
    public AudioMixer mixer;
    [Header("# BGM")]
    public AudioClip[] bgmClips;
    public float bgmVolume;
    public AudioSource bgmPlayer;

    [Header("# SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;

    public enum Sfx { Dead, Hit, Dash, Talk, Hp, Button, Hpplus, Jump, Buy, Small, Big }

    public enum Bgm { Start, Room, Stage, Dash, Shop, Story, End }

    void Awake()
    {
        Init();
    }

    void Init()
    {
        GameObject bgmobject = new GameObject("BgmPlayer");
        bgmobject.transform.parent = transform;
        bgmPlayer = bgmobject.AddComponent<AudioSource>();
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;

        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].volume = sfxVolume;
        }
    }

    public void PlayBgm(Bgm bgm)
    {
        bgmPlayer.clip = bgmClips[(int)bgm];
        bgmPlayer.Play();
    }

    public void StopBgm()
    {
        bgmPlayer.Stop();
    }

    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }

    public void ToggleBgm()
    {
        bgmPlayer.mute = !bgmPlayer.mute;

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index].mute = !sfxPlayers[index].mute;
        }
    }


}
