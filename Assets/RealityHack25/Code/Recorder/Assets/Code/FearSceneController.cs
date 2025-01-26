using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FearSceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject Fear;

    [SerializeField]
    private bool loadSingleFear = false;

    [SerializeField]
    private bool loadFears = false;

    [SerializeField]
    private string NextSceneName;

    void Start()
    {
        if (loadFears)
        {
            DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
            FileInfo[] info = dir.GetFiles("*.wav");

            foreach (FileInfo f in info)
            {
                Debug.Log(f.Directory + " // " + f.Name);
                StartCoroutine(LoadFileAudio(f.FullName));
            }
        }
        if(loadSingleFear)
        {
            FearController fear = SpawnFear();
        }
    }
    IEnumerator LoadFileAudio(string url)
    {
        using (var www = new WWW(url))
        {
            yield return www;
            //source.clip = www.GetAudioClip();
            FearController fear = SpawnFear();
            fear.LoadFear(www.GetAudioClip());
        }
    }

    public FearController SpawnFear()
    {
        FearController fear = Instantiate(Fear).GetComponent<FearController>();
        gameObject.transform.Rotate(Vector3.up, Random.Range(-45, 45));
        fear.gameObject.transform.position = new Vector3(0, 1, 0) + gameObject.transform.forward * 0.7f;
        gameObject.transform.rotation = Quaternion.identity;
        return fear;
    }

    public void NextScene(AudioClip clip)
    {
        StartCoroutine(_NextScene(clip.length+1));
    }
    IEnumerator _NextScene(float timer)
    {
        yield return new WaitForSeconds(timer);
    }
}