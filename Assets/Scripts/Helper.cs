using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class Helper {
    public static float GetAnimationDuration(string clipName, Animator animator) {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips) {
            if (clip.name == clipName) {
                return clip.length;
            }
        }

        Debug.Log("ERROR! No clip with this name was found: " + clipName);
        return 0;
    }

    public static bool IsPlayingAnimation(string stateName, Animator animator) {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}