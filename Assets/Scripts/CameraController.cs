using UnityEngine;

namespace Geekbrains
{
<<<<<<< Updated upstream
    public sealed class CameraController : MonoBehaviour
=======
    public PlayerBall Player;
    Vector3 _shakerOffset;
    public Vector3 _offset;

    private void Start ()
>>>>>>> Stashed changes
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
