using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] bool isMusicVideo = false;

    private void Start()
    {
        if (isMusicVideo)
        {
            GetComponent<Animator>().SetBool("isMusicVideo", true);
        }
    }
}