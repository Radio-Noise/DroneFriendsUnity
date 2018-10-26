using UnityEngine;
using System.Collections;

public class CapCam : MonoBehaviour {
    public int Width = 1920;            //キャプチャーボードからの映像を入れる幅を定義し数値を代入
    public int Height = 1080;           //キャプチャーボードからの映像を入れる高さを定義し数値を代入
    public int FPS = 60;                //FPS(Flame Per Second)を定義し数値を代入
    public string CameraName = "";      //カメラの名前を入れる配列を定義     

    void Start()
    {
        var devices = WebCamTexture.devices;        //デバイスの名前を入れる文字列定義しテクスチャしたデバイスの名前を代入

        for (int i = 0; i < devices.Length; i++)    //デバイスの名前の文字数分ループさせる
        {
            if (devices[i].name.Contains("AVerMedia") )      //デバイスの名前にAVerMadeiaが含まれていたら
            {
                CameraName = devices[i].name;       //読み取ったデバイスの名前を代入
            }
        }

        if (devices.Length > 0)     //デバイスの名前がなにか入っていたら
        {
            if (CameraName == "")       //CameraNameになにも入っていなかったら
            {
                CameraName = devices[0].name;       //読み取ったデバイスの名前を代入
            }

            var capcamTexture = new WebCamTexture(CameraName, Width, Height, FPS);      //定義した、幅、高さ、FPSをcapcamTextureに代入
            GetComponent<Renderer>().material.mainTexture = capcamTexture;      //代入した幅、高さ、FPSを送る
            capcamTexture.Play();           //capcamTextureを動作させる
        }
    }
}
