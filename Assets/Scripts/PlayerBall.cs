using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    int _jumpPower = 300;
    public float Speed = 3.0f;
    bool _dead = false;
    [SerializeField]
    Rigidbody _rigdbody;
    public Transform Transform;

    private void Update()
    {
        if (_dead) return;
        
        if (Input.GetKeyUp(KeyCode.Space)) Jump();
        if (Input.GetKeyDown(KeyCode.LeftControl)) Transform.localScale = new Vector3(1, 0.5f, 1);
        if (Input.GetKeyUp(KeyCode.LeftControl)) Transform.localScale = new Vector3(1, 1, 1);
    }

    private void Jump()
    {
        _rigdbody.AddForce(Vector3.up * _jumpPower);
    }

    private void FixedUpdate()
    {
        if (!_dead) Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        _rigdbody.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * Speed);
    }

    public void GameLoaded(bool dead)
    {
        _dead = dead;
        _rigdbody.isKinematic = dead;
    }

    public void StartGame()
    {
        _dead = false;
        _rigdbody.isKinematic = false;
    }

    public void Win()
    {
        _rigdbody.isKinematic = true;
    }

    public void Lose()
    {
    _dead = true;
    _rigdbody.isKinematic = true;
    }
}