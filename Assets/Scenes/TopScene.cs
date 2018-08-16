using System.Threading.Tasks;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes {
public class TopScene : MonoBehaviour {

	async void Start(){

		Debug.Log("実行開始!");

		var commonScene = await CommonScene.Initialize();

		Debug.Log($"commonScene method call test: {commonScene.Test()}");

		// UniRx.Asyncコードメモ
		// 参考: https://qiita.com/toRisouP/items/4445b6b9bf00e49eb147
		Debug.Log($"test {await TestAsync()}");

		async UniTask<string> TestAsync(){
			Debug.Log("delay pre");
			await Task.Delay(300);
			Debug.Log("delay post");
			return await Task.Run(() => "testtest!");
		}
	}

	#region UI Events

		public void OnToSecondButtonClicked() {
			SceneManager.LoadSceneAsync("Second");
		}

	#endregion

	}//Scene class

}//namespace