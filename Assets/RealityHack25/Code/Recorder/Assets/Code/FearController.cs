using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearController : MonoBehaviour
{
    /// <summary>
    /// Private Vars
    /// </summary>
    private AudioClip fear = null;
    /// <summary>
    /// Editor Visible
    /// </summary>
    [SerializeField]
    private Recorder.Recorder recorder;
    [SerializeField]
    private AudioSource source = null;
    [SerializeField]
    private GameObject CleanMesh;
    [SerializeField]
    private GameObject GrabbedMesh;
    [SerializeField]
    private GameObject RecordedMesh;
    [SerializeField]
    private GameObject Particles;
    [SerializeField]
    private GameObject Tooltip;
    [SerializeField]
    private FearSceneController SceneController;


    private void Start()
    {
        if (source == null) source = GetComponent<AudioSource>();
        if (recorder == null) recorder = FindObjectOfType<Recorder.Recorder>();
        if (SceneController == null) SceneController = FindObjectOfType<FearSceneController>();
        
    }
    public void OnGrab()
    {
        if(fear == null)
        {
            recorder.StartRecording();
            CleanMesh.SetActive(false);
            GrabbedMesh.SetActive(true);
            recorder.RecordingTimeText = GetComponentInChildren<TMPro.TMP_Text>();
        }
        else
        {
            source.Play();
        }
    }
    public void OnRelease()
    {
        if (fear == null)
        {
            fear = recorder.SaveRecording("Fear");
            source.clip = fear;
            GrabbedMesh.SetActive(false);
            RecordedMesh.SetActive(true);
            Particles.SetActive(true);
            source.Play();

            Tooltip.SetActive(false);
            if (fear.length<5)
            {
                
                SceneController.SpawnFear();
            }
            else
            {
                SceneController.NextScene(fear);
            }
            
        }
    }
    public void LoadFear(AudioClip clip)
    {
        fear = clip;
        source.clip = fear;
        CleanMesh.SetActive(false);
        RecordedMesh.SetActive(true);
        Tooltip.SetActive(false);
    }
}
