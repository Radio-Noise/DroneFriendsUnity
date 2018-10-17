using UnityEngine;

public class CapCam : MonoBehaviour {
    public int Width = 1920;
    public int Height = 1080;
    public int FPS = 60;
    public string CameraName = "";

    void Start()
    {
        var devices = WebCamTexture.devices;

        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].name.Contains("AVerMedia") || devices[i].name.Contains("USB Camera"))
            {
                CameraName = devices[i].name;
            }
        }

        if (devices.Length > 0)
        {
            if (CameraName == "")
            {
                CameraName = devices[0].name;
            }

            var capcamTexture = new WebCamTexture(CameraName, Width, Height, FPS);
            GetComponent<Renderer>().material.mainTexture = capcamTexture;
            capcamTexture.Play();
        }
    }
}
