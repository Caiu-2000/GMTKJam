
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] RawImage video;
    [SerializeField] VideoPlayer player;
   

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        player.Play();
        video.gameObject.SetActive(true);
    }
}
