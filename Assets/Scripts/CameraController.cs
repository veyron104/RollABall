using UnityEngine;

namespace Geekbrains
{
    public sealed class CameraController : MonoBehaviour
    {
        public PlayerBall Player;
        public Vector3 _offset;

        private void Start ()
        {
            _offset = transform.position - Player.transform.position;
        }

        private void LateUpdate ()
        {
            transform.position = Player.transform.position + _offset;
        }
    }
}
