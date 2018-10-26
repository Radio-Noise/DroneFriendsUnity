using UnityEngine;
using UnityEngine.XR;       //トラッキングのための名前空間の宣言

public class CameraController : MonoBehaviour {
    [SerializeField] Camera target;     //アタッチしたカメラをtargetとして定義

    void Start()
    {   
        GameObject.Find("Camera").transform.position = new Vector3(0, 0, -17);          //カメラの位置を定義
        GameObject.Find("Camera").transform.rotation = new Quaternion(0, 0, 0, 0);      //カメラの回転を定義　※Vector3ではないので注意
        XRDevice.DisableAutoXRCameraTracking(target, true);                             //targetのトラッキング
    }

    void Update()
    { 
        if (Input.GetKeyDown("a"))
        {
            XRDevice.DisableAutoXRCameraTracking(target, false);    //targetのトラッキングを無効化
        }
        if (Input.GetKeyDown("s"))
        {
            XRDevice.DisableAutoXRCameraTracking(target, true);     //targetのトラッキング
        }
    }

}
