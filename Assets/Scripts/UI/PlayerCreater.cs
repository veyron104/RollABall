using UnityEngine;
using UnityEngine.UI;

public class PlayerCreater : MonoBehaviour
{
    [SerializeField]
    InputField _nickNameInput;
    bool _correctNickName = false;
    [SerializeField]
    GameLoader _gameLoader;

    public void NickNameChanged()
    {
        _correctNickName = _nickNameInput.text.Length > 0;
    }

    public void CreateNewPlayer()
    {
        if (!_correctNickName) return;
        _correctNickName = false;
        _gameLoader.CreateNewPlayer(_nickNameInput.text);
        _nickNameInput.text = "";
        gameObject.SetActive(false);
    }
}