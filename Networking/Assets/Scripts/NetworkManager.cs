using System;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

	private readonly string PublicGameName = "jf.spielwiese.networking";

	private HostData[] _hostData;

	[Tooltip( "The player prefab" )]
	public GameObject PlayerPrefab;

	public void StartServer() {
		Network.InitializeServer( 16 , 25002 , false );
		MasterServer.RegisterHost( PublicGameName , "Networking Tutorial Server" , "Test implementation of server code." );
	}

	private void Start() {
		InvokeRepeating( "RefreshHostList" , 0 , 3 );
	}

	private void OnServerInitialized() {
		Debug.Log( "Server initialized" );
		SpawnPlayer();
	}

	[HideInInspector]
	public void OnMasterServerEvent( MasterServerEvent masterServerEvent ) {
		switch ( masterServerEvent ) {

			case MasterServerEvent.RegistrationFailedGameName:
				Debug.Log( "RegistrationFailedGameName" );
				break;
			case MasterServerEvent.RegistrationFailedGameType:
				Debug.Log( "RegistrationFailedGameType" );
				break;
			case MasterServerEvent.RegistrationFailedNoServer:
				Debug.Log( "RegistrationFailedNoServer" );
				break;
			case MasterServerEvent.RegistrationSucceeded:
				Debug.Log( "RegistrationSucceeded" );
				break;
			case MasterServerEvent.HostListReceived:
				Debug.Log( "HostListReceived" );
				break;
			default:
				throw new ArgumentOutOfRangeException( "masterServerEvent" , masterServerEvent , null );
		}
	}

	private void RefreshHostList() {
		Debug.Log( "Refreshing" );

		MasterServer.RequestHostList( PublicGameName );

		_hostData = MasterServer.PollHostList();

		if ( _hostData == null || _hostData.Length == 0 ) {
			Debug.Log( "No active servers found" );
		} else {
			Debug.Log( string.Format( "{0} Host(s) found" , _hostData.Length ) );
		}
	}

	private void SpawnPlayer() {
		Network.Instantiate( PlayerPrefab , new Vector3( 0 , 0 , 0 ) , Quaternion.identity , 0 );
	}

}
