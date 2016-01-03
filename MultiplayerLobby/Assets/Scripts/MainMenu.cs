using System.Threading;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

public class MainMenu : MonoBehaviour
{
	public Canvas MainMenuCanvas;

	public Canvas OptionsCanvas;

	private void Start()
	{
		Fade(MainMenuCanvas, false);
	}

	public void ShowOptions()
	{
		Fade(MainMenuCanvas);
		Fade(OptionsCanvas, false);
	}

	public void Quit()
	{
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}

	private void Fade(Canvas canvas, bool fade = true)
	{
		canvas.GetComponent<Animator>().SetTrigger(fade ? "fade" : "appear");
	}
}
