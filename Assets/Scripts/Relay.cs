using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;

public class Relay : MonoBehaviour
{
	[SerializeField]
	private short maxPlayers = 4;
	private string joinCode;
	public TMPro.TextMeshPro textMeshProUGUI;

	private async void Start()
	{


		
		await UnityServices.InitializeAsync();

//sign the user out first
		AuthenticationService.Instance.SignOut();
		AuthenticationService.Instance.ClearSessionToken();

		

		AuthenticationService.Instance.SignedIn += () =>
		{
			Debug.Log("Signed In" + AuthenticationService.Instance.PlayerId);
		};
		await AuthenticationService.Instance.SignInAnonymouslyAsync();
	}

	public async void AllocateRelay()
	{
		try
		{
			Debug.Log("Host - Creating an allocation.");

			// Important: Once the allocation is created, you have ten seconds to BIND
			Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxPlayers-1); // takes number of connections allowed as argument. you can add a region argument

			joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
			textMeshProUGUI.text = joinCode;
			Debug.Log(joinCode);

			RelayServerData relayServerData = new RelayServerData(allocation, "dtls");
			NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

			NetworkManager.Singleton.StartHost();
		} 
		catch (RelayServiceException e)
		{
			Debug.LogError(e.Message);
		}
	}

	public async void JoinRelay(string joinCode)
	{
		//  = "7BPNFW";
		try
		{
			Debug.Log("Joining Relay with " + joinCode);
			JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

			RelayServerData relayServerData = new RelayServerData(joinAllocation, "dtls");
			NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

			NetworkManager.Singleton.StartClient();
			textMeshProUGUI.text = "Join Code"+joinCode;
		}
		catch (RelayServiceException e)
		{
			Debug.LogError(e.Message);
		}
	}
}
