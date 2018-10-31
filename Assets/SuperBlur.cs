using UnityEngine;

	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Effects/Super Blur", -1)]
	public class SuperBlur : SuperBlurBase
	{
		
		void OnRenderImage (RenderTexture source, RenderTexture destination) 
		{
			if (blurMaterial == null || UIMaterial == null) return;

			int tw = source.width >> downsample;
			int th = source.height >> downsample;

			var rt = RenderTexture.GetTemporary(tw, th, 0, source.format);

			Graphics.Blit(source, rt);

			if (RenderModeFake == RenderModeFake.Screen)
			{
				Blur(rt, destination);
			}
			else if (RenderModeFake == RenderModeFake.UI)
			{
				Blur(rt, rt);
				UIMaterial.SetTexture(Uniforms._BackgroundTexture, rt);
				Graphics.Blit(source, destination);
			}
			else if (RenderModeFake == RenderModeFake.OnlyUI)
			{
				Blur(rt, rt);
				UIMaterial.SetTexture(Uniforms._BackgroundTexture, rt);
			}

			RenderTexture.ReleaseTemporary(rt);
		}
			
	}

