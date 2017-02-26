using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : Singleton<PageManager> {
    protected PageManager () { }

    public MenuPage[] pages;

    private MenuPage currentPage;

    void Start() {
        Initialise();
    }

    void Initialise() {
        currentPage = pages[0];
        currentPage.Initilise();

        foreach(MenuPage p in pages) {
            if(p != currentPage)
                p.Exit();
        }
    }


    public void OpenPage(MenuPage page) {
        currentPage.Exit();
        currentPage = page;
        currentPage.Initilise();
    }


}
