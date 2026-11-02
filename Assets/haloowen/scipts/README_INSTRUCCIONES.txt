HALLOWEEN: LA ULTIMA LUZ - PAQUETE DE SCRIPTS PARA UNITY 6
=========================================================

IMPORTANTE
Este ZIP contiene scripts de gameplay, NO el proyecto Unity completo ni un APK.
Como el proyecto original no fue adjuntado como ZIP, no es posible configurar
automáticamente tu jerarquía, tus referencias, tu cámara ni generar un APK
probado con tu escenario. Importa estos archivos en una copia de tu proyecto.

INSTALACION
1. Haz una copia de seguridad del proyecto.
2. Descomprime este ZIP.
3. Copia los archivos .cs a Assets/Scripts/ (puedes crear carpetas VR y Gameplay).
4. Vuelve a Unity y espera a que termine de compilar.
5. Abre Window > General > Console. Resuelve cualquier error rojo antes de seguir.

CONFIGURACION BASICA
A. MIRADA / RETICULA
- Selecciona la cámara que mira al mundo (normalmente Main Camera dentro de Player).
- Añade GazeInteractor.
- Arrastra esa cámara al campo Vr Camera si no se asigna automáticamente.
- Crea una retícula UI Image en el centro de la vista y asígnala a Reticle.
- Para un indicador radial, configura la Image Type como Filled y Fill Method como Radial 360.
- Los objetos interactivos deben tener Collider habilitado.
- El jugador activa al mirar continuamente durante 1.5 segundos por defecto.

B. CALABAZA
- Añade PumpkinInteraction a la calabaza marcada.
- Asigna Pumpkin Light (una luz hija de la calabaza, apagada al inicio).
- Opcionalmente asigna un Renderer y un material de activación.
- Puedes asignar MissionUI y un panel de confirmación.

C. CAMPANA
- Añade BellInteraction a la campana.
- Opcionalmente asigna el objeto móvil en Moving Part.
- Asigna MissionUI y un panel de confirmación.
- La campana requiere que el sello ya esté activado.

D. DIALOGO / MENSAJES
- Crea Canvas con Text (Legacy) y un panel que contenga el texto.
- Añade MissionUI a un objeto administrador.
- Asigna Message Text y Message Panel.
- Para diálogos dentro del mundo, usa un Canvas World Space en cada zona y orienta el texto hacia el jugador.
- Puedes usar dos MissionUI distintos, uno por zona, si quieres mensajes separados.
- Este paquete usa UnityEngine.UI.Text para evitar dependencia obligatoria de TextMeshPro.

E. SCREEN FADE
- Crea un Canvas de pantalla (Screen Space - Overlay) con una Image negra estirada a toda la pantalla.
- Deja el alfa de la imagen en 0 al inicio.
- Añade ScreenFade al Canvas o a un objeto administrador y asigna Fade Image.
- La imagen debe estar por encima de la escena en el orden de renderizado.
- No uses una imagen de pantalla completa en World Space para este fundido.

F. TELETRANSPORTACION
- Crea tres objetos vacíos en posiciones seguras: TP_Entrada, TP_Camino y TP_Refugio.
- Crea un objeto visible para cada punto (por ejemplo un círculo o pedestal) y añade Collider.
- Añade TeleportPoint al objeto visible.
- Asigna Player Root al Transform raíz que debe moverse (no la cámara si está dentro de un rig).
- Asigna Destination al Transform vacío de destino.
- Asigna ScreenFade y, si el jugador lo usa, su CharacterController.
- Para el punto que lleva al refugio, usa Requirement = SealActivated.
- El punto de retorno o el portal final puede usar Requirement = BellActivated si corresponde.
- Revisa que las posiciones no estén dentro de paredes ni objetos.
- No dupliques Player, cámara, EventSystem ni sistema XR.

G. PORTAL FINAL
- Añade PortalInteraction al objeto del portal y Collider.
- Asigna MissionUI.
- Opcionalmente asigna las visualizaciones cerrada y abierta.
- El portal solo completa la misión cuando el sello y la campana están activados.

H. REINICIO
- Añade RestartMission a un objeto.
- En un UI Button, en On Click agrega el objeto y el método RestartMission.RestartCurrentScene.
- Asegúrate de que la escena esté incluida en File > Build Profiles > Scene List (Unity 6).

GOOGLE CARDBOARD / ANDROID
Estos scripts no instalan ni configuran Google Cardboard. Debes configurar el paquete XR/Google Cardboard compatible con el proyecto y probarlo en un Android real. No cambies el sistema XR existente sin verificar primero cómo está configurado.

NOTAS
- Revisa la Console tras copiar los archivos.
- Los mensajes, luces, materiales, destinos, Canvas y referencias se asignan en el Inspector.
- Para evitar activaciones repetidas, el interactor bloquea la activación mientras se mantiene la misma mirada.
- Si tu cámara o tu controlador XR utiliza un rig especial, mueve el objeto raíz del rig y no una cámara hija.
