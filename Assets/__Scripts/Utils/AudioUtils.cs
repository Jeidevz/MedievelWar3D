using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioUtils : MonoBehaviour {

    public static void playRandomClipFromAudioclipArray(AudioSource audioSource, AudioClip[] audioClips)
    {
        audioSource.PlayOneShot(ArrayUtils.getRandomClipFromAudioList(audioClips));
    }
}
