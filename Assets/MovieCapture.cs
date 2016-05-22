using UnityEngine;

public class MovieCapture : MonoBehaviour
{
    public Camera captureCamera;

    // Movie Options
    [Header("Movie Settings")]
    public string targetFolderName;
    [Tooltip("Movie frame rate")]
    public int FrameRate = 60;
    [Tooltip("Editor window resolution multiplier")]
    public int superSampling = 2;

    private int width;
    private int height;
    private bool isCaptureFramerate = false;

    // 
    RenderTexture renderTexture;
    Texture2D texture2D;

    void Awake()
    {
        Time.captureFramerate = FrameRate;
        System.IO.Directory.CreateDirectory(targetFolderName);
    }

    void Start()
    {
        // Set desired width & length
        width = Screen.width * superSampling;
        height = Screen.height * superSampling;
    }

    void LateUpdate()
    {
        TakeScreenshot();
    }

    /// <summary>
    /// Capture & save screenshot
    /// </summary>
    void TakeScreenshot()
    {
        renderTexture = new RenderTexture(width, height, 24);
        captureCamera.targetTexture = renderTexture;
        texture2D = new Texture2D(width, height, TextureFormat.RGB24, false);
        captureCamera.Render();
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        captureCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);
        byte[] bytes = texture2D.EncodeToPNG();
        Destroy(texture2D);
        System.IO.File.WriteAllBytes(string.Format("{0}/shot{1:D04}.png", targetFolderName, Time.frameCount), bytes);
    }
}