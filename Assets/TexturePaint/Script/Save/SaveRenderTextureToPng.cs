using UnityEngine;
using System.Collections;
using System.IO;

namespace Es.TexturePaint
{
public class SaveRenderTextureToPng : MonoBehaviour {

    public RenderTexture RenderTextureRef;
    public DynamicCanvas _dynamicCanvas;

    // Use this for initialization
    void Start () {
            RenderTextureRef = _dynamicCanvas.paintMainTexture2;
    }

    // Update is called once per frame
    void Update () {
        //savePng();
    }

    public void savePng()
    {

        Texture2D tex = new Texture2D(RenderTextureRef.width, RenderTextureRef.height, TextureFormat.RGB24, false);
        RenderTexture.active = RenderTextureRef;
        tex.ReadPixels(new Rect(0, 0, RenderTextureRef.width, RenderTextureRef.height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        Object.Destroy(tex);

        //Write to a file in the project folder
            #if UNITY_EDITOR
            File.WriteAllBytes("/Users/macpro/bg.png", bytes);
            #elif UNITY_ANDROID
            File.WriteAllBytes("/storage/sdcard0/test/bg.png", bytes);
            #endif


    }
}
}