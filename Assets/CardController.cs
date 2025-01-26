using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CardController : MonoBehaviour
{
    [Header("- Enable -")]
    [SerializeField] UnityEvent OnEnableEvent;
    [SerializeField] float EnableDelay;
    [Header("- Deactivate -")]
    [SerializeField] UnityEvent OnDisableEvent;
    [SerializeField] float DisableDelay;
    
    private void OnEnable()
    {
        StartCoroutine(OnEnableCoroutine());
    }

    private IEnumerator OnEnableCoroutine()
    {
        yield return new WaitForSeconds(EnableDelay);
        OnEnableEvent.Invoke();
    }
    public void Deactivate()
    {
        StartCoroutine(OnDisableCoroutine());
    }

    private IEnumerator OnDisableCoroutine()
    {
        yield return new WaitForSeconds(DisableDelay);
        OnDisableEvent.Invoke();
    }
}
