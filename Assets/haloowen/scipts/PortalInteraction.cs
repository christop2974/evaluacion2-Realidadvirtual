using UnityEngine;

/// <summary>Final interaction. Only completes the mission after both game actions.</summary>
public class PortalInteraction : GazeTarget
{
    [SerializeField] private MissionUI missionUI;
    [SerializeField] private GameObject portalOpenVisual;
    [SerializeField] private GameObject portalClosedVisual;

    private bool completed;

    private void Awake()
    {
        if (portalOpenVisual != null) portalOpenVisual.SetActive(false);
        if (portalClosedVisual != null) portalClosedVisual.SetActive(true);
    }

    public override void Activate()
    {
        if (completed) return;

        if (!MissionProgress.MissionComplete)
        {
            if (missionUI != null)
                missionUI.ShowMessage("El portal sigue cerrado. Activa la calabaza y la campana.");
            return;
        }

        completed = true;

        if (portalOpenVisual != null) portalOpenVisual.SetActive(true);
        if (portalClosedVisual != null) portalClosedVisual.SetActive(false);

        if (missionUI != null)
            missionUI.ShowFinal();

        Debug.Log("Halloween: misión completada.");
    }
}
