using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CustomNetworkManager : NetworkManager {

	public void StartupGame()
	{
		SetPort();
		NetworkManager.singleton.StartServer();
		NetworkManager.singleton.ServerChangeScene("networkStart");
	}

	public void JoinGame()
	{
		SetIPAddress();
		SetPort();
		StartClient();
	}

	void SetIPAddress()
	{
		string ipAddress = GameObject.Find("InputIPAddress").transform.FindChild("Text").GetComponent<Text>().text;
		networkAddress = ipAddress;
	}

	void SetPort()
	{
		networkPort = 7777;
	}

	void OnLevelWasLoaded(int level)
	{
		if(level == 0)
		{
			SetupStartMenuSceneButtons();
		}
		else
		{
			//SetupClientSceneButtons();
		}
	}

	void SetupStartMenuSceneButtons()
	{
		GameObject.Find("ButtonStartGame").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("ButtonStartGame").GetComponent<Button>().onClick.AddListener(StartupGame);

		GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.AddListener(JoinGame);
	}

	//void SetupClientSceneButtons()
	//{
	//	GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.RemoveAllListeners();
	//	GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopServer);
	//}
}
