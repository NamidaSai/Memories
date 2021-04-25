using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayClickSFX);
    }

    private void PlayClickSFX()
    {
        PlaySFX("click");
    }

    private void PlaySFX(string soundName)
    {
        FindObjectOfType<AudioManager>().Play(soundName);
    }
}