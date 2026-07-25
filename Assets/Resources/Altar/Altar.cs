using UnityEngine;

public class Altar : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject panel;
    public string InteractMessage => "Improve yourself";

    public void Interact()
    {
        if (panel.activeSelf == true) return;
        panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Player player = GeneralHandler.Instance.GetPlayer();
        if (Vector3.Distance(transform.position, player.transform.position) > 10f) panel.SetActive(false);
    }
}
