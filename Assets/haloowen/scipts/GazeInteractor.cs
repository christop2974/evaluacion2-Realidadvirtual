using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attach to the active player's camera. Uses the camera forward direction
/// for gaze selection and activates a target after activationTime seconds.
/// </summary>
public class GazeInteractor : MonoBehaviour
{
    [SerializeField] private Camera vrCamera;
    [SerializeField] private Image reticle;
    [SerializeField, Min(0.1f)] private float activationTime = 1.5f;
    [SerializeField, Min(0.1f)] private float maxDistance = 20f;

    private GazeTarget currentTarget;
    private float gazeTimer;
    private bool activated;

    private void Awake()
    {
        if (vrCamera == null)
            vrCamera = GetComponent<Camera>();

        if (reticle != null)
        {
            reticle.enabled = true;
            reticle.fillAmount = 0f;
        }
    }

    private void Update()
    {
        if (vrCamera == null)
            return;

        GazeTarget target = null;
        Ray ray = new Ray(vrCamera.transform.position, vrCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            target = hit.collider.GetComponentInParent<GazeTarget>();

        if (target != currentTarget)
        {
            if (currentTarget != null)
                currentTarget.OnGazeExit();

            currentTarget = target;
            gazeTimer = 0f;
            activated = false;

            if (currentTarget != null)
                currentTarget.OnGazeEnter();
        }

        if (currentTarget == null)
        {
            UpdateReticle(false, 0f);
            return;
        }

        if (!activated)
        {
            gazeTimer += Time.deltaTime;
            if (gazeTimer >= activationTime)
            {
                activated = true;
                currentTarget.Activate();
            }
        }

        UpdateReticle(true, activated ? 1f : gazeTimer / activationTime);
    }

    private void UpdateReticle(bool lookingAtTarget, float progress)
    {
        if (reticle == null)
            return;

        reticle.enabled = true;
        reticle.color = lookingAtTarget ? Color.yellow : Color.white;
        reticle.fillAmount = Mathf.Clamp01(progress);
    }
}
