using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {

	private Canvas _pauseCanvas;
	public GameObject PlayerGameObject;

	private AudioSource _audioSource;
	private PlayerController _playerController;

	public void Start() {
		_pauseCanvas = GetComponent<Canvas>();
		_audioSource = GetComponent<AudioSource>();
		_playerController = PlayerGameObject.GetComponent<PlayerController>();

		_pauseCanvas.enabled = false;
	}

	public void Update() {
		if ( _playerController.gameOver ) {
			return;
		}

		if ( Input.GetButtonDown( "Cancel" ) ) {
			Pause();
		}
	}

	public void Pause() {
		_audioSource.Play();

		_pauseCanvas.enabled = !_pauseCanvas.enabled;

		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	public void Quit() {
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}

}
