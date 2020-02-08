using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameDirector : MonoBehaviour {

    GameObject dobby;
    GameObject goal;
    GameObject distanceMeter;
    CanvasGroup canvas2;
    Image charaImage;
    public Text charaText;
    float charaAlfa;
    public float resultDistance;
    public bool gameOver;
    public float distance;
    public float fadeTime;
    public int rank;
    public Sprite dobbyImage, danImage,hamaImage,foiImage,namaeImage,suneImage;
    public AudioSource rank1Se, rank2Se, rank3Se, rank4Se, rank5Se,rank6Se;
    bool resultFlag = false;
    public string point;
    


    // Use this for initialization
    void Start () {

        this.dobby = GameObject.Find("Dobby");
        this.goal = GameObject.Find("Goal");
        this.distanceMeter = GameObject.Find("Distance");

        this.canvas2 = GameObject.Find("Canvas2").GetComponent<CanvasGroup>();
        this.charaImage = GameObject.Find("CharaImage").GetComponent<Image>();
        this.charaText = GameObject.Find("CharaText").GetComponent<Text>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        rank1Se = audioSources[0];
        rank2Se = audioSources[1];
        rank3Se = audioSources[2];
        rank4Se = audioSources[3];
        rank5Se = audioSources[4];
        rank6Se = audioSources[5];
        point = "\nクリックでバイブスを上げる";


    }
	
	// Update is called once per frame
	void Update () {
        if (dobby.GetComponent<DobbyMove>().run == true) point = "\nクリックでブレーキ";

        //リザルトを更新し続けないためのif
        if (gameOver != true)
        {
            this.distance = this.goal.transform.position.x - this.dobby.transform.position.x;

            this.distanceMeter.GetComponent<Text>().text = "クラブまで" + distance.ToString("F2") + "m"+point ;
        }

        //停止から数秒後にゲームオーバー（暗転はFadeScript）
        if (this.dobby.GetComponent<DobbyMove>().check == true && this.dobby.GetComponent<DobbyMove>().dobbySpeed == 0)

        {
            Invoke("GameOver", fadeTime);
        }


    }

    void GameOver()
    {
        resultDistance = this.distance;
        gameOver = true;

        //クリアランク分け

        if (resultDistance <= 500f && resultDistance > 70f) rank = 6;
        if (resultDistance < -10f && resultDistance > -150f) rank = 5;
        if (resultDistance <= 70f && resultDistance > 10f) rank = 4;
        if (resultDistance <= 10f && resultDistance >= -10f) rank = 3;
        if (resultDistance <= 3f && resultDistance >= -3f) rank = 2;
        if (resultDistance <= 0.5f && resultDistance >= -0.5f) rank = 1;

        Resurt();
    }

    void Resurt()
    {
                this.distanceMeter.GetComponent<Text>().text = "クラブまで" + distance.ToString("F2") + "m" + "\nクリアランク" +rank.ToString("");

        canvas2.interactable = true;
        canvas2.alpha = charaAlfa;
        charaAlfa += 0.02f;

        if(resultFlag == false){
            resultFlag = true;
            switch (rank)
            {
                case 1://バットガイ
                    charaImage.sprite = dobbyImage;
                    this.charaText.text = "You are the bad guy!!";
                    rank1Se.PlayOneShot(rank1Se.clip);

                    break;
                case 3://グリフィンドール
                    charaImage.sprite = danImage;
                    this.charaText.text = "Bad guyに100点じゃ！！";
                    rank2Se.PlayOneShot(rank2Se.clip);
                    break;

                case 4://赤毛のやつ
                    charaImage.sprite = foiImage;
                    this.charaText.text = "穢れたやつ...";
                    rank3Se.PlayOneShot(rank3Se.clip);
                    break;

                case 5://レヴィオッサ
                    charaImage.sprite = hamaImage;
                    this.charaText.text = "あなたのはレヴィオサ～よ";
                    rank4Se.PlayOneShot(rank4Se.clip);
                    break;
                case 6://名前のやつ
                    charaImage.sprite = namaeImage;
                    this.charaText.text = "バイブスを上げるのだ、Dobby...";
                    rank5Se.PlayOneShot(rank5Se.clip);
                    break;

                case 2://すねのやつ
                    charaImage.sprite = suneImage;
                    this.charaText.text = "いうて吾輩の完敗のやつだわ\n";
                    rank2Se.PlayOneShot(rank2Se.clip);
                    break;
                default:
                    break;
                    
            }
        }
            
    }

}
