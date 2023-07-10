using UnityEngine;

[CreateAssetMenu]
public class HumanoidAudioLibrarySO : ScriptableObject {

    public AudioClip[] normalAttackAudioClips;
    public AudioClip[] heavyAttackAudioClips;
    public AudioClip[] stepAudioClips;
    public AudioClip[] deathAudioClips;
    public AudioClip[] hurtAudioClips;
}
