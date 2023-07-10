using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidAudioLibrary : AudioLibrary {
    public HumanoidAudioLibrarySO presetAudioLibrary;
    [HideInInspector]
    public AudioClip[] normalAttackAudioClips;
    [HideInInspector]
    public AudioClip[] heavyAttackAudioClips;
    [HideInInspector]
    public AudioClip[] deathAudioClips;
    [HideInInspector]
    public AudioClip[] stepAudioClips;
    [HideInInspector]
    public AudioClip[] hurtAudioClips;

    protected new void Awake()
    {
        base.Awake();

        normalAttackAudioClips = presetAudioLibrary.normalAttackAudioClips;
        heavyAttackAudioClips = presetAudioLibrary.heavyAttackAudioClips;
        stepAudioClips = presetAudioLibrary.stepAudioClips;
        deathAudioClips = presetAudioLibrary.deathAudioClips;
        hurtAudioClips = presetAudioLibrary.hurtAudioClips;
    }
}
