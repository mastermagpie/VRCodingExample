using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MenuButton {
    public MenuPage pageToOpen;

    public override void OnClick() {
        base.OnClick();
        PageManager.Instance.OpenPage(pageToOpen);
    }


}
