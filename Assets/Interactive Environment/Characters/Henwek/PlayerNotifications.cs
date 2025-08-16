using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class PlayerNotifications : MonoBehaviour
{
    public GameObject ui;
    public int showDuration = 10;
    public TMP_Text text;
    void Start()
    {
        
    }


    public void showUI(string content)
    {
        if (ui.activeSelf &&content==text.text) return;
        text.text= content;
        ui.SetActive(true);
        HideText();

    }

    private async void HideText()
    {
        await Delay();
        ui.SetActive(false);
    }
    public async Task Delay()
    {
        await Task.Delay(showDuration*1000);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
