using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBearWorld : MonoBehaviour
{
    public IEnumerator LoadBearScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("PlayBear", LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
