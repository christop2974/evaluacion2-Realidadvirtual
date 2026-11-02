using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>Attach to a UI Button's OnClick event, or a gaze target if desired.</summary>
public class RestartMission : MonoBehaviour
{
    public void RestartCurrentScene()
    {
        MissionProgress.Reset();
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }
}
