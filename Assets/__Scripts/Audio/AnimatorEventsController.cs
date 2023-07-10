using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEventsController : EventsController {
    public HumanoidAudioLibrary audioLibrary;
    protected GearsSystem equips;

    protected override void Awake()
    {
        base.Awake();
        equips = GetComponent<GearsSystem>();
    }

    public void playFootStepSound()
    {
        AudioUtils.playRandomClipFromAudioclipArray(audioSource, audioLibrary.stepAudioClips);
    }

    public void playHurtSound()
    {
        AudioUtils.playRandomClipFromAudioclipArray(audioSource, audioLibrary.hurtAudioClips);
    }

    public void playDeadSound()
    {
        AudioUtils.playRandomClipFromAudioclipArray(audioSource, audioLibrary.deathAudioClips);
    }

    public void weaponCannotHit()
    {
        if (equips)
        {
            equips.primary.GetComponent<Weapon>().weaponCannotHit();
        }
    }

    public void weaponCanHit()
    {
        if (equips)
        {
            equips.primary.GetComponent<Weapon>().weaponCanHit();
        }
    }
}
