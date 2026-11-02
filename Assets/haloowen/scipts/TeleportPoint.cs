using System.Collections;
using UnityEngine;

/// <summary>
/// Gaze-activated teleport destination. Set the player's root Transform and
/// a destination Transform in the Inspector. Gate options enforce mission order.
/// </summary>
public class TeleportPoint : GazeTarget
{
    public enum AccessRequirement
    {
        None,
        SealActivated,
        BellActivated
    }

    [Header("Teleport")]
    [SerializeField] private Transform playerRoot;
    [SerializeField] private Transform destination;
    [SerializeField] private ScreenFade screenFade;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private AccessRequirement requirement = AccessRequirement.None;
    [SerializeField] private MissionUI missionUI;
    [SerializeField] private string blockedMessage = "Todavía no puedes pasar.";

    private bool teleporting;

    public override void Activate()
    {
        if (teleporting)
            return;

        if (!HasAccess())
        {
            if (missionUI != null)
                missionUI.ShowMessage(blockedMessage);
            else
                Debug.Log(blockedMessage);

            return;
        }

        if (playerRoot == null || destination == null)
        {
            Debug.LogError($"TeleportPoint '{name}': asigna Player Root y Destination en el Inspector.", this);
            return;
        }

        StartCoroutine(TeleportRoutine());
    }

    private bool HasAccess()
    {
        switch (requirement)
        {
            case AccessRequirement.SealActivated:
                return MissionProgress.SealActivated;
            case AccessRequirement.BellActivated:
                return MissionProgress.MissionComplete;
            default:
                return true;
        }
    }

    private IEnumerator TeleportRoutine()
    {
        teleporting = true;

        if (screenFade != null)
            yield return screenFade.FadeOut();

        bool controllerWasEnabled = characterController != null && characterController.enabled;
        if (controllerWasEnabled)
            characterController.enabled = false;

        playerRoot.SetPositionAndRotation(destination.position, destination.rotation);

        if (controllerWasEnabled)
            characterController.enabled = true;

        // Avoid leaving the view black if references or timing change.
        if (screenFade != null)
            yield return screenFade.FadeIn();

        teleporting = false;
    }
}
