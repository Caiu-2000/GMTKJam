using UnityEngine;

public class AnvilCon : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject panel;

    public string InteractMessage =>"Build";

    public void Interact()
    {
        if (panel.activeSelf == true) return;
        panel.SetActive(true);
    }

    void Update()
    {
        Player player = GeneralHandler.Instance.GetPlayer();
        if (Vector3.Distance(transform.position, player.transform.position) > 10f) panel.SetActive(false);
    }
}
