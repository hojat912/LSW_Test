using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExecutable
{
    void Execute();
    void SetAction(Action execute);
}
