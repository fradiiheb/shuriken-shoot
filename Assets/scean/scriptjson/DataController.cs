using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour {
	private myscore[] myscore;
	private string gameDataFileName="data.json";
	public string name;
	public int score;
	// Use this for initialization
	void Start ()  
	{

		DontDestroyOnLoad (gameObject);
		LoadGameData ();
		SceneManager.LoadScene ("MenuScreen");
	}
	private void LoadGameData()
	{
		string filePath = Path.Combine (Application.streamingAssetsPath, gameDataFileName);
		if (File.Exists (filePath)) {
			string dataAsJson = File.ReadAllText (filePath);
			GameData loadedData = JsonUtility.FromJson<GameData> (dataAsJson);
			myscore = loadedData.allRoundData;
		} else
		{
			Debug.LogError ("Canot load gamedata");
		}
	}

	public myscore GetCurrentRoundData()
	{
		return myscore [0];
	}
}
