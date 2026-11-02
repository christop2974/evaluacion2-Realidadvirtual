using UnityEngine;

/// <summary>Shared mission state for the two required actions.</summary>
public static class MissionProgress
{
    public static bool SealActivated { get; private set; }
    public static bool BellActivated { get; private set; }

    public static bool CanEnterShelter => SealActivated;
    public static bool CanOpenPortal => SealActivated && BellActivated;
    public static bool MissionComplete => CanOpenPortal;

    public static void ActivateSeal() => SealActivated = true;
    public static void ActivateBell() => BellActivated = true;

    public static void Reset()
    {
        SealActivated = false;
        BellActivated = false;
    }
}
