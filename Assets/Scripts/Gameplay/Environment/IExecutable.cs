using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gameplay.Environment
{
    public interface IExecutable
    {
        void Execute();
        void SetAction(Action execute);
        void SetAction(KeyCode keyCode, Action execute);

    }
}