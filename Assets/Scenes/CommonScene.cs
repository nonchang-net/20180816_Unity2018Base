using System.Threading.Tasks;
// using Scenes.CommonSceneScripts;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes {
public class CommonScene : MonoBehaviour {

	private static readonly string COMMON_SCENE_NAME = "Common";
	private static readonly string COMMON_SCENE_GAMEOBJECT_NAME = "CommonScene";
	private static CommonScene instance;

	/// <summary>
	/// 共通コンポーネント初期化＋インスタンス取得
	/// 要件メモ
	/// - CommonSceneが付いてないシーンを再生した時は自動で初期化して待機する手順を確立
	///     - シーンを読み込んでない時は自動で読み込む必要がある
	/// </summary>
	public static async UniTask<CommonScene> Initialize(){
		if (ContainsScene(COMMON_SCENE_NAME)) return instance;
		// ここで共通コンポーネントを初期化するなど
		// 分業のため、共通コンポーネントはなんらかの方法で小分けできるようにしたい
		await SceneManager.LoadSceneAsync(COMMON_SCENE_NAME,LoadSceneMode.Additive);
		await Task.Delay(Random.Range(100,500));

		instance = GameObject.Find(COMMON_SCENE_GAMEOBJECT_NAME).GetComponent<CommonScene>();
		DontDestroyOnLoad(instance);
		// DontDestroy後はシーン自体は不要
		await SceneManager.UnloadSceneAsync(COMMON_SCENE_NAME);

		Debug.Log($"CommonScene Initalize finish");
		return instance;
	}

	// シーンが読み込み済みか確認
	// 参考: http://asterisks.netlify.com/2016/02/11/unity-exists-scene/
	// もっといい方法ないのだろうか？
	static bool ContainsScene(string sceneName) {
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			if (SceneManager.GetSceneAt(i).name == sceneName) return true;
		}
		return false;
	}

	public string Test(){
		return "testtest";
	}

}//Scene class
}//namespace