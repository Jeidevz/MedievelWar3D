using UnityEngine;

public abstract class AudioLibrary : MonoBehaviour {
    protected AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
}
