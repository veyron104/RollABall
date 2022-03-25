using System.Collections;
using UnityEngine;

public sealed class CameraController : MonoBehaviour
{
    public PlayerBall Player;
    public Vector3 _shakerOffset;
    public Vector3 _offset;

    private void Start ()
    {
        _offset = transform.position - Player.transform.position;
        GameManager.s_GameManager.PickerdUpEvent.AddListener(CameraShaker);
    }

    void CameraShaker()
    {
        StartCoroutine(CameraShakerCor());
    }

    IEnumerator CameraShakerCor()
    {
        for (int i = 0; i < 20; i++)
        {
            _shakerOffset = new Vector3(Shake(10), Shake(10), Shake(10)) * Time.deltaTime;
            yield return new WaitForSeconds(0.05f);
        }
        _shakerOffset = Vector3.zero;
    }

    float Shake(float range)
    {
        return Random.Range(-range, range);
    }

    private void LateUpdate ()
    {
        transform.position = Player.transform.position + _offset + _shakerOffset;
    }
}