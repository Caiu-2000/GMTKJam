using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Anvil : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject panel;
    public string InteractMessage => "YUNQUE";

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
