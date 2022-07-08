
using UnityEngine;

namespace Gameplay.Environment
{

    [RequireComponent(typeof(IExecutable))]
    public class Curtain : MonoBehaviour
    {
        private bool _isOpen;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            IExecutable executable = GetComponent<IExecutable>();
            executable.SetAction(Execute);
        }

        private void Execute()
        {
            _isOpen = !_isOpen;
            _animator.SetBool("IsOpen", _isOpen);
        }
    }
}