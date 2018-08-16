using System.Threading.Tasks;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes {
public class SecondScene : MonoBehaviour {

	async void Start(){

		var commonScene = await CommonScene.Initialize();
		Debug.Log($"シーン2: {commonScene.Test()}");

	}


	#region UI Events

		public void OnToTopSceneButtonClicked() {
			SceneManager.LoadSceneAsync("Top");
		}

	#endregion
	
}//Scene class

}//namespace