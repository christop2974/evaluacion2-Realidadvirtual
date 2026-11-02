using UnityEngine;

/// <summary>First game action: light the marked pumpkin and activate the seal.</summary>
public class PumpkinInteraction : GazeTarget
{
    [SerializeField] private Light pumpkinLight;
    [SerializeField] private Renderer pumpkinRenderer;
    [SerializeField] private Material activatedMaterial;
    [SerializeField] private GameObject confirmationMessage;
    [SerializeField] private MissionUI missionUI;

    private Material originalMaterial;

    private void Awake()
    {
        if (pumpkinRenderer != null)
            originalMaterial = pumpkinRenderer.material;

        if (pumpkinLight != null)
            pumpkinLight.enabled = false;

        if (confirmationMessage != null)
            confirmationMessage.SetActive(false);
    }

    public override void Activate()
    {
        if (MissionProgress.SealActivated)
            return;

        MissionProgress.ActivateSeal();

        if (pumpkinLight != null)
            pumpkinLight.enabled = true;

        if (pumpkinRenderer != null && activatedMaterial != null)
            pumpkinRenderer.material = activatedMaterial;

        if (confirmationMessage != null)
            confirmationMessage.SetActive(true);

        if (missionUI != null)
            missionUI.ShowMessage("¡La última luz ha vuelto! Sigue hacia el refugio.");

        Debug.Log("Halloween: sello de entrada activado.");
    }

    public void ResetVisual()
    {
        if (pumpkinLight != null)
            pumpkinLight.enabled = false;

        if (pumpkinRenderer != null && originalMaterial != null)
            pumpkinRenderer.material = originalMaterial;

        if (confirmationMessage != null)
            confirmationMessage.SetActive(false);
    }
}
