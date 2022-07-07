using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(IExecutable))]
public class Seller : MonoBehaviour
{
    [SerializeField] private CharacterDialogue _characterDialogue;
    [SerializeField] private string[] _dialogues;
    private int _dialogueIndex;

    private void Awake()
    {
        IExecutable executable = GetComponent<IExecutable>();
        executable.SetAction(Speack);
    }

    private void Speack()
    {
        _characterDialogue.SetData(_dialogues[_dialogueIndex]);
        _dialogueIndex++;
        _dialogueIndex %= _dialogues.Length;
    }
}

