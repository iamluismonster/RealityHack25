using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CardController : MonoBehaviour
{
    [Header("- Enable -")]
    [SerializeField] UnityEvent OnEnableEvent;
    [SerializeField] float EnableDelay;
    private void OnEnable()
    {
        StartCoroutine(OnEnableCoroutine());
    }

    private IEnumerator OnEnableCoroutine()
    {
        yield return new WaitForSeconds(EnableDelay);
        OnEnableEvent.Invoke();
    }

}
