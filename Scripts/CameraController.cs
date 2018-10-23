using UnityEngine;
using UnityEngine.XR;

public class CameraController : MonoBehaviour {
    [SerializeField] Camera target;

    void Start()
    {   
        GameObject.Find("Camera").transform.position = new Vector3(0, 0, -17);
        GameObject.Find("Camera").transform.rotation = new Quaternion(0, 0, 0, 0);
        XRDevice.DisableAutoXRCameraTracking(target, true);
    }

    void Update()
    { 
        if (Input.GetKeyDown("a"))
        {
            XRDevice.DisableAutoXRCameraTracking(target, false);
        }
        if (Input.GetKeyDown("s"))
        {
            XRDevice.DisableAutoXRCameraTracking(target, true);
        }
    }

}
