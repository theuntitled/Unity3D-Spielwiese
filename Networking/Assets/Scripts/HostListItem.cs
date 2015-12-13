using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HostListItem : MonoBehaviour {

	public Button JoinButton;

	public Text ServerNameText;

	void Start () {
		ServerNameText.text = string.Empty;
	}

	public void SetText(string name) {
		ServerNameText.text = name;
	}

}
