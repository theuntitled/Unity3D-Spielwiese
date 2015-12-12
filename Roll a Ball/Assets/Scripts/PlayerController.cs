using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text winText;
	public Text countText;

	private int _pickupCount;
	private Rigidbody _rigidbody;

	void Start () {
		_pickupCount = 0;
		_rigidbody = GetComponent<Rigidbody>();

		winText.text = "";
		UpdateCount();
	}
	
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis( "Horizontal" );
		float moveVertical = Input.GetAxis( "Vertical" );

		Vector3 movement = new Vector3( moveHorizontal , 0.0f , moveVertical );

		_rigidbody.AddForce( movement * speed );
	}

	void OnTriggerEnter( Collider other ) {
		if ( other.gameObject.CompareTag( "Pickup" ) ) {
			other.gameObject.SetActive( false );

			_pickupCount++;

			UpdateCount();
		}
	}

	private void UpdateCount() {
		countText.text = string.Format("Score: {0}", _pickupCount);

		if ( _pickupCount >= 9 ) {
			winText.text = "Game over!";
		}
	}
}
