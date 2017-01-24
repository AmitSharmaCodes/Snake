using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
public class IncreaseBrightness : PostEffectsBase
{

    [Range(1.0f, 2.0f)]
    public float intensity = 1;

    private Material brightnessMaterial;
    public Shader brightness;

    // Called by camera to apply image effect
    public override bool CheckResources()
    {
        CheckSupport(false);

        brightnessMaterial = CheckShaderAndCreateMaterial(brightness, brightnessMaterial);

        if (!isSupported)
            ReportAutoDisable();
        return isSupported;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (CheckResources() == false)
        {
            Graphics.Blit(source, destination);
            return;
        }

        brightnessMaterial.SetFloat("intensity", MainMenuController.Instance.getBrightness());
        Graphics.Blit(source, destination, brightnessMaterial);
    }
}
