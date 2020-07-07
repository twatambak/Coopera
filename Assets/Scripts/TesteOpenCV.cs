namespace OpenCvSharp.Demo
{
    using UnityEngine;

    using OpenCvSharp;
    using OpenCvSharp.Tracking;
    using OpenCvSharp.Demo;
    using System.Net;
    using UnityEngine.UI;
    using System.Diagnostics;
    using Debug = UnityEngine.Debug;

    /*
     * O que eu tenho pra fazer?
     * 1. Fazer a máscara para identificar a cor verde.
     * 2. Identificar o contorno da bola.
     * 3. Filtrar contornos dentro da máscara.
     * 4. Criar uma bounding box que contenha o objeto filtrado.
     * 5. Colocar um tracker para essa bounding box.
     */

    /*
    * Dúvidas?
    * 1. Pq o range que eu defino para máscara não funciona?
    * 2. Como limitar a identificação de contornos?
    * 3. 
    * 4. 
    * 5. 
    */

    public class TesteOpenCV : WebCamera
    {

        // Downscale na imagem
        const float downScale = 0.33f;
        public bool colorSelected = false;
        // Colors
        Scalar lowerColor = new Scalar(); //183, 255, 0
        Scalar upperColor = new Scalar(); //0, 255, 85

        // Inicialização
        protected override void Awake()
        {
            base.Awake();
            forceFrontalCamera = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        /// <param name="mousePosition"></param>
        private void ConvertPixelRGB2HSV(Texture2D output, Vector2 mousePosition)
        {
            Color cor;
            cor = output.GetPixel((int)mousePosition.x, (int)mousePosition.y);
            float h, s, v;
            Color32 cor32 = new Color(cor[0], cor[1], cor[2], 1);
            Color.RGBToHSV(cor, out h, out s, out v);
            Color32 corToHSV = new Color(h, s, v, 1);
            lowerColor = new Scalar(cor32[0] - 10, cor32[1] - 10, cor32[2] - 40);
            upperColor = new Scalar(cor32[0] + 10, cor32[1] + 10, cor32[2] + 40);
            Debug.Log("Cor: " + cor32.ToString());
            Debug.Log("Cor HSV: " + corToHSV.ToString());
            Debug.Log("Lower color: " + lowerColor.ToString());
            Debug.Log("Upper color: " + upperColor.ToString());    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        protected override bool ProcessTexture(WebCamTexture input, ref Texture2D output)
        {
            Size tam = new Size(3, 3);
            Mat image = Unity.TextureToMat(input, TextureParameters);
            Mat imageDownscale = image.Resize(Size.Zero, downScale, downScale);
            Mat imageGaussian = imageDownscale.GaussianBlur(tam, 0, 0);
            Mat imageHSV = imageGaussian.CvtColor(ColorConversionCodes.BGR2HSV);

            if (!colorSelected)
            {
                if (Input.GetMouseButton(0))
                {
                    ConvertPixelRGB2HSV(output, Input.mousePosition);
                    colorSelected = true;
                }
                output = Unity.MatToTexture(imageGaussian, output);
                return output;
            }
            else
            {

                Mat mask = imageHSV.InRange(lowerColor, upperColor);

                mask = mask.Erode(new Mat());
                mask = mask.Dilate(new Mat());

                //output = Unity.MatToTexture(mask, output);

                // Identificação de formas
                //Mat image = Unity.TextureToMat(input, TextureParameters);
                /*Mat grayMat = imageGaussian.CvtColor(ColorConversionCodes.BGR2GRAY);
                Mat thresh = grayMat.Threshold(127, 255, ThresholdTypes.BinaryInv);

                Point[][] contours;
                Cv2.FindContours(thresh, out contours, out _, RetrievalModes.Tree, ContourApproximationModes.ApproxNone, null);

                foreach (Point[] contour in contours)
                {
                    double length = Cv2.ArcLength(contour, true);
                    Point[] approx = Cv2.ApproxPolyDP(contour, length * 0.2, true);
                    string shapeName = null;

                    Scalar color = new Scalar();

                    if (approx.Length == 3)
                    {
                        shapeName = "Triangulo";
                        color = new Scalar(255, 251, 0);
                    }
                    else if (approx.Length == 4)
                    {
                        OpenCvSharp.Rect rect = Cv2.BoundingRect(contour);
                        if (rect.Width / rect.Height <= 0.1)
                        {
                            shapeName = "Quadrado";
                            color = new Scalar(255, 0, 0);
                        }
                        else
                        {
                            shapeName = "Retangulo";
                            color = new Scalar(0, 255, 187);
                        }
                    }
                    else if (approx.Length >= 10)
                    {
                        shapeName = "Circulo";
                        color = new Scalar(230, 0, 255);
                    }

                    if (shapeName != null)
                    {
                        Moments m = Cv2.Moments(contour);
                        int cx = (int)(m.M10 / m.M00);
                        int cy = (int)(m.M01 / m.M00);

                        Cv2.DrawContours(imageGaussian, new Point[][] { contour }, 0, color, -1);
                        Cv2.PutText(imageGaussian, shapeName, new Point(cx - 50, cy), HersheyFonts.HersheySimplex, 1.0, new Scalar(0, 0, 0));
                    }                
                }*/

                if(Input.GetKey(KeyCode.R))
                {
                    colorSelected = false;
                }
                output = Unity.MatToTexture(mask, output);
                return output;
            }
        }
    }
}

