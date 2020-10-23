using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace RudeBlooper.SpaceFigure
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            TouchSimulation.Enable();
        }
    }
}
