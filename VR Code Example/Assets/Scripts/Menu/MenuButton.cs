using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuButton : MonoBehaviour {
    public float highlightScaleMultiplier = 1.1f;
    public float highlightDuration = 0.3f;
    public float loadTime = 3f;
    public float unloadTime = 0.2f;

    public Image loadingBar;
    public Color disabledColor = Color.grey;

    private Vector3 idleScale;
    private Color defaultColor;
    private bool isEnabled = true;
    

    void Start() {
        Initialise();
    }

    void Initialise() {
        idleScale = transform.localScale;
    }

    public void SetHighlight(bool highlighting) {
        if (highlighting)
            Highlight();
        else
            Idle();
    }

    void Highlight() {
        transform.DOScale(transform.localScale * highlightScaleMultiplier, highlightDuration);

        if (isEnabled)
            Load();
    }


    void Idle() {
        transform.DOScale(idleScale, highlightDuration);
        Unload();
    }

    void Load() {
        loadingBar.DOKill();
        loadingBar.fillAmount = 0f;
        loadingBar.DOFillAmount(1f, loadTime).SetEase(Ease.Linear).OnComplete(OnClick);
    }

    void Unload() {
        loadingBar.DOKill();
        loadingBar.DOFillAmount(0f, unloadTime).SetEase(Ease.Linear);
    }


    public void Disable() {
        isEnabled = false;
        GetComponent<Image>().color = disabledColor;
    }

    public void Enable() {
        isEnabled = true;
        GetComponent<Image>().color = defaultColor;
    }


    public virtual void OnClick() {
        Debug.Log("Clicked Button");
    }
}
