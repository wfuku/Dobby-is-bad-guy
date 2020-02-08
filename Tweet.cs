using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tweet : MonoBehaviour {

    public int rank;
    string charaText;
    GameObject directror;
    string resurtDistance;
	// Use this for initialization
	void Start () {

        this.directror = GameObject.Find("GameDirector");

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UnityRoomTweet() {
        this.rank = directror.GetComponent<GameDirector>().rank;

        switch (rank)
        {
            case 1://バットガイ
                this.charaText = "You are the bad guy!!";

                break;
            case 3://グリフィンドール
                this.charaText = "Bad guyに100点じゃ！！";
                break;

            case 4://赤毛のやつ
                this.charaText = "穢れたやつ...";
                break;

            case 5://レヴィオッサ
                this.charaText = "あなたのはレヴィオサ～よ";
                break;
            case 6://名前のやつ
                this.charaText = "バイブスを上げるのだ、Dobby...";
                break;

            case 2://すねのやつ
                this.charaText = "いうて吾輩の勝ちだわ";
                break;
            default:
                break;
        }

        this.resurtDistance = directror.GetComponent<GameDirector>().resultDistance.ToString("F2");

        naichilab.UnityRoomTweet.Tweet("[dobby]", "クリアランク:" +rank.ToString("") + "  クラブまでの距離" +"["+ resurtDistance + "m]" + "\n" + "「" + charaText + "」"+ "\nhttps://unityroom.com/games/dobby\n#DobbyIsTheBadGuy #unityroom");
    }

    public void TweetResurt()
    {
        this.rank = directror.GetComponent<GameDirector>().rank;

        switch (rank)
        {
            case 1://バットガイ
                this.charaText = "You are the bad guy!!";

                break;
            case 2://グリフィンドール
                this.charaText = "Bad guyに100点じゃ！！";
                break;

            case 3://赤毛のやつ
                this.charaText = "穢れたやつ...";
                break;

            case 4://レヴィオッサ
                this.charaText = "あなたのはレヴィオサ～よ";
                break;
            case 5://名前のやつ
                this.charaText = "バイブスを上げるのだ、Dobby...";
                break;

            case 6://すねのやつ
                this.charaText = "いうて吾輩の勝ちだわ";
                break;
            default:
                break;
        }

        this.resurtDistance = directror.GetComponent<GameDirector>().resultDistance.ToString("F2");


        Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL("クリアランク:" + rank.ToString("")
            +" クラブまでの距離"+resurtDistance+"m"+"\n"+"「"+charaText+"」"+"\n\nhttps://unityroom.com/games/dobby"+"\n#DobbyIsTheBadGuy #unityroom"));
    }
}
