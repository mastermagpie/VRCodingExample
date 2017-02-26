using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GazeControl : MonoBehaviour {
    public Transform gazePointer;
    public float fadeCursorDuration = 0.3f;

    private bool gazeEnabled = true;
    private MenuButton currentButton;
    private Vector3 gazeIdleScale;

    void Start() {
        Initialise();
    }

    void Initialise() {
        gazeIdleScale = gazePointer.transform.localScale;
    }

    void FixedUpdate() {
        Gaze();
    }

    void Gaze() {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, 100.0f)) {
            gazePointer.position = hit.point;

            if (hit.transform.tag == "MenuButton") {
                HitMenuButton(hit);
            } else if (hit.transform.tag == "MenuBackground") {
                HitMenuBG();
            } else {
                HitNothing();
            }
        }
    }

    void HitMenuButton(RaycastHit hit) {
        gazePointer.transform.DOScale(gazeIdleScale * 1.3f, 0.2f);

        SetGazeState(true);
        SetButton(hit.transform.GetComponent<MenuButton>());
    }


    void HitMenuBG() {
        gazePointer.transform.DOScale(gazeIdleScale, 0.2f);
        
        SetGazeState(true);
        SetButton(null);
    }

    void HitNothing() {
        gazePointer.transform.DOScale(gazeIdleScale, 0.2f);

        SetGazeState(false);
        SetButton(null);
    }

    void SetButton(MenuButton button) {
        if (currentButton == button) {
            return;
        }

        if (button != null) {
            if (currentButton != null) {
                currentButton.SetHighlight(false);
            }

            currentButton = button;
            currentButton.SetHighlight(true);
        } else {
            if (currentButton != null) {
                currentButton.SetHighlight(false);
                currentButton = null;
            }
        }
    }

    void SetGazeState(bool gazeState) {
        if (gazeState == gazeEnabled)
            return;

        if (gazeState) {
            gazePointer.GetComponent<CanvasGroup>().DOFade(1, fadeCursorDuration);
        } else {
            gazePointer.GetComponent<CanvasGroup>().DOFade(0, fadeCursorDuration);
        }

        gazeEnabled = gazeState;
    }
}
