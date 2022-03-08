using UnityEngine;

namespace Geekbrains
{
    public class PlayerBall : MonoBehaviour
    {
        private int t { get; set; }
        public float Speed = 3.0f;
        public bool Dead = false;
        public Rigidbody Rigdbody;
        public Transform Transf;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Jump();
            if (Input.GetKeyDown(KeyCode.LeftControl)) Transf.localScale = new Vector3(1, 0.5f, 1);
            if (Input.GetKeyUp(KeyCode.LeftControl)) Transf.localScale = new Vector3(1, 1, 1);
        }

        private void Jump()
        {
            t = 6;
        }

        private void FixedUpdate()
        {
            if (!Dead) Move();
        }

        private void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            Rigdbody.AddForce(movement * Speed);
        }
    }
}