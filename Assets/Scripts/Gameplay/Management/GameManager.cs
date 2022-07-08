using UnityEngine;
using DependencyInjection;
using EventSystem;

namespace Managment
{
    public class GameManager : MonoBehaviour
    {
        public static IServiceLocator ServiceLocator;
        private void Awake()
        {
            ServiceLocator = new ServiceLocator();
            ServiceLocator.AddService(typeof(IEvent), new EventController());
        }
    }
}