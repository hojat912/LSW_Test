using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputExecute : IExecutable
{
    [SerializeField]
    private KeyCode _executeKey;
    public bool CanExecute { get; set ; }

    public KeyCode ExecuteKey => _executeKey;






    public void Execute()
    {
        if (CanExecute)
        {

        }
    }

    public void SetAction(Action execute)
    {
        throw new NotImplementedException();
    }
}
