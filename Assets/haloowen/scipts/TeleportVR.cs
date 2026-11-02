using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TeleportVR : MonoBehaviour
{
    [SerializeField] private Image fadeImage; // Asigna aquí tu panel negro de UI en el Inspector
    [SerializeField] private float fadeDuration = 0.5f;

    // Métodos personalizados que TeleportVR está buscando:
    public IEnumerator CerrarYEsperar()
    {
        yield return StartCoroutine(FadeRoutine(0f, 1f));
    }

    public IEnumerator AbrirYEsperar()
    {
        yield return StartCoroutine(FadeRoutine(1f, 0f));
    }

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