﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlaySoundOnInteract : MonoBehaviour
{
    public SamplesList Sound;

    public ActionList Action;

    private VRTK_InteractableObject io;
    private VRTK_SnapDropZone sdz;

    public enum ActionList
    {
        Snaped,
        Unsnaped,
        Touched,
        Untouched,
        Grabbed,
        Ungrabbed
    }

    private void OnDestroy()
    {
        switch (Action)
        {
            case ActionList.Snaped:
                if (sdz != null) sdz.ObjectSnappedToDropZone -= ObjectSnapped;
                break;
            case ActionList.Unsnaped:
                if (sdz != null) sdz.ObjectUnsnappedFromDropZone -= ObjectUnsnapped;
                break;
            case ActionList.Touched:
                if (io != null) io.InteractableObjectTouched -= ObjectTouched;
                break;
            case ActionList.Untouched:
                if (io != null) io.InteractableObjectUntouched -= ObjectUntouched;
                break;
            case ActionList.Grabbed:
                if (io != null) io.InteractableObjectGrabbed -= ObjectGrabbed;
                break;
            case ActionList.Ungrabbed:
                if (io != null) io.InteractableObjectUngrabbed -= ObjectUngrabbed;
                break;
        }
    }

    void Start()
    {
        io = GetComponent<VRTK_InteractableObject>();
        sdz = GetComponent<VRTK_SnapDropZone>();

        switch (Action)
        {
            case ActionList.Snaped:
                if (sdz != null) sdz.ObjectSnappedToDropZone += ObjectSnapped;
                break;
            case ActionList.Unsnaped:
                if (sdz != null) sdz.ObjectUnsnappedFromDropZone += ObjectUnsnapped;
                break;
            case ActionList.Touched:
                if (io != null) io.InteractableObjectTouched += ObjectTouched;
                break;
            case ActionList.Untouched:
                if (io != null) io.InteractableObjectUntouched += ObjectUntouched;
                break;
            case ActionList.Grabbed:
                if (io != null) io.InteractableObjectGrabbed += ObjectGrabbed;
                break;
            case ActionList.Ungrabbed:
                if (io != null) io.InteractableObjectUngrabbed += ObjectUngrabbed;
                break;
        }
    }

    private void Play()
    {
        GameController.Instance.SoundManager.Play3DAt(Sound, transform.position);
    }

    private void ObjectSnapped(object sender, SnapDropZoneEventArgs e)
    {
        Play();
    }

    private void ObjectUnsnapped(object sender, SnapDropZoneEventArgs e)
    {
        Play();
    }

    private void ObjectTouched(object sender, InteractableObjectEventArgs e)
    {
        Play();
    }

    private void ObjectUntouched(object sender, InteractableObjectEventArgs e)
    {
        Play();
    }

    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        Play();
    }

    private void ObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        Play();
    }
}