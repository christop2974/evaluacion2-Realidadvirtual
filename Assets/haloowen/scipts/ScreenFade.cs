using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 0.5f;

    // Métodos que TeleportPoint está buscando:
    public IEnumerator FadeOut()
    {
        yield return StartCoroutine(FadeRoutine(0f, 1f));
    }

    public IEnumerator FadeIn()
    {
        yield return StartCoroutine(FadeRoutine(1f, 0f));
    }

    // Métodos anteriores por si otro script los usa
    public IEnumerator CerrarYEsperar() => FadeOut();
    public IEnumerator AbrirYEsperar() => FadeIn();

    private IEnumerator FadeRoutine(float alphaInicial, float alphaFinal)
    {
        if (fadeImage == null) yield break;

        float tiempoTranscurrido = 0f;
        Color color = fadeImage.color;

        while (tiempoTranscurrido < fadeDuration)
        {
            tiempoTranscurrido += Time.deltaTime;
            float alpha = Mathf.Lerp(alphaInicial, alphaFinal, tiempoTranscurrido / fadeDuration);
            color.a = alpha;
            fadeImage.color = color;
            yield return null;
        }

        color.a = alphaFinal;
        fadeImage.color = color;
    }
}