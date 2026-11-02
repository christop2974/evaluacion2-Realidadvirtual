using UnityEngine;

/// <summary>Second game action: activate the bell and unlock the portal.</summary>
public class BellInteraction : GazeTarget
{
    [SerializeField] private GameObject confirmationMessage;
    [SerializeField] private MissionUI missionUI;
    [SerializeField] private Transform movingPart;
    [SerializeField] private Vector3 activationRotation = new Vector3(0f, 0f, 25f);

    private Quaternion originalRotation;

    private void Awake()
    {
        if (movingPart != null)
            originalRotation = movingPart.localRotation;

        if (confirmationMessage != null)
            confirmationMessage.SetActive(false);
    }

    public override void Activate()
    {
        if (!MissionProgress.SealActivated)
        {
            if (missionUI != null)
                missionUI.ShowMessage("Primero debes encender la calabaza de la entrada.");
            return;
        }

        if (MissionProgress.BellActivated)
            return;

        MissionProgress.ActivateBell();

        if (movingPart != null)
            movingPart.localRotation = originalRotation * Quaternion.Euler(activationRotation);

        if (confirmationMessage != null)
            confirmationMessage.SetActive(true);

        if (missionUI != null)
            missionUI.ShowMessage("¡El camino está abierto! Busca el portal.");

        Debug.Log("Halloween: campana activada; portal desbloqueado.");
    }

    public void ResetVisual()
    {
        if (movingPart != null)
            movingPart.localRotation = originalRotation;

        if (confirmationMessage != null)
            confirmationMessage.SetActive(false);
    }
}
