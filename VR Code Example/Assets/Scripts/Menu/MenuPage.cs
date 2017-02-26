using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuPage : MonoBehaviour {
	
    public virtual void Initilise() {
        gameObject.SetActive(true);
        GetComponent<CanvasGroup>().DOFade(1f, 0.2f);
    }

    public virtual void Exit() {
        GetComponent<CanvasGroup>().DOFade(0f, 0.2f).OnComplete(Hide);
    }

    void Hide() {
        gameObject.SetActive(false);
    }

}
