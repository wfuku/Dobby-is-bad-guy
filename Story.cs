using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour {

    public GameObject StoryCanvas;
    public CanvasGroup story;
    public bool storyMode = false;
    public int flag = 0;
    public AudioSource buttonSe;
    Text storyText;

    void Start() {
        this.buttonSe = GetComponent<AudioSource>();
        this.StoryCanvas = GameObject.Find("Story");
        this.story = GameObject.Find("Story").GetComponent<CanvasGroup>();
        this.storyText = GameObject.Find("StoryText").GetComponent<Text>();

    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && storyMode == true) {
            flag += 1;
            storyText.text = "「Dobby」はめちゃめちゃBad guyのやつなので、一度だけなら\n筋力でミニバンを止めることができます。\n果たしてBad guyはワンブレーキでクラブホグワーツに\nたどり着くことができるでしょうか";




            if (Input.GetMouseButtonDown(0) && flag == 2){
                story.alpha = 0;
                storyMode = false;
                story.blocksRaycasts = false;
               
            }
                }
    }

    public void GoStory() {
        buttonSe.PlayOneShot(buttonSe.clip);
        storyText.text = "年に一度のパリぴの祭典、「ウルトラホグワーツ2017」\nゲストDJとして招待された魔法界一のBad guy\n「Dobby」だったが、嫉妬した陰キャのやつに妨害魔法を\nかけられてしまい愛車のミニバンの\nブレーキが効かなくなってしまった！";
        flag = 0;
        story.alpha = 1;
        storyMode = true;
        story.blocksRaycasts = true;
    }

}
