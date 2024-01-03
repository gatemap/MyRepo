using System.Windows;
using OpenCvSharp;

namespace OpenCVStudy01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            versionTextBox.Text = Cv2.GetVersionString();

            //PracticeImageConvert();
            //PracticeHistogram();
            //PracticeVector();
            //PracticePoint();
            //PracticeScalar();
            PracticeRect();
        }

        void PracticeImageConvert()
        {
            // exe 파일 있는 위치에 이미지 파일을 두면 됨
            Mat img = Cv2.ImRead("방긋로아콘.jpg");
            Mat[] cvtImgs = new Mat[5];

            for (int i = 0; i < cvtImgs.Length; i++)
                cvtImgs[i] = new Mat();

            //Cv2.CvtColor(img, img2, ColorConversionCodes.RGB2GRAY);
            Cv2.CvtColor(img, cvtImgs[0], ColorConversionCodes.RGB2GRAY);
            Cv2.CvtColor(img, cvtImgs[1], ColorConversionCodes.BGR2YCrCb);
            Cv2.CvtColor(img, cvtImgs[2], ColorConversionCodes.BGR2HSV);
            Cv2.CvtColor(img, cvtImgs[3], ColorConversionCodes.BGR2Lab);
            Cv2.CvtColor(img, cvtImgs[4], ColorConversionCodes.BGR2Luv);


            // 새창 생성
            //Cv2.ImShow("Image Test", img2);

            originBox.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(img);
            convertBox1.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(cvtImgs[0]);
            convertBox2.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(cvtImgs[1]);
            convertBox3.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(cvtImgs[2]);
            convertBox4.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(cvtImgs[3]);
            convertBox5.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(cvtImgs[4]);
        }

        void PracticeHistogram()
        {
            // Mat = Matrix
            Mat originImg = Cv2.ImRead("카단.jpg", ImreadModes.ReducedColor4);
            Mat gray = new Mat();
            Mat hist = new Mat();

            // 가로 150, 세로 크기는 원본 이미지 크기만큼 1로만 가득차 있음
            // CV_8Uc1 : 8bit 1channel 이미지
            Mat res = Mat.Ones(new OpenCvSharp.Size(150, originImg.Height), MatType.CV_8UC1);
            Mat dist = new Mat();

            Cv2.CvtColor(originImg, gray, ColorConversionCodes.BGR2GRAY);

            // 히스토그램 값 생성
            // 원본 matrix, 채널 수, 이미지 마스크, 출력 매트릭스, 차원 수, 히스토그램 크기(가로), 각 차원에 대한 색상값 범위
            Cv2.CalcHist(new Mat[] { gray }, new int[] { 0 }, null, hist, 1, new int[] { 256 },
                new Rangef[] { new Rangef(0, 256) });

            // 정규화(최대 최소값을 정해주고 그 값에 따라서 매핑해주는 함수)
            // 원본 매트릭스, 출력 매트릭스, 최소값(MinMax일 경우), 최대값(MinMax일 경우), 변환 방식
            Cv2.Normalize(hist, hist, 0, 255, NormTypes.MinMax);

            // 히스토그램 값을 갖고 값의 크기만큼 선의 길이를 정하고 선을 그린다
            // 입출력될 mat, 1번점(x, y), 2번점(x,y), 선 타입
            for (int i = 0; i < hist.Rows; i++)
                Cv2.Line(res, new OpenCvSharp.Point(i, originImg.Height), new OpenCvSharp.Point(i, originImg.Height - hist.Get<float>(i)), Scalar.White);

            // Matrix 이어붙이기. 세로 길이 동일해야함
            Cv2.HConcat(new Mat[] { gray, res }, dist);
            Cv2.ImShow("Concat Image", dist);

            // 사용자 입력 들어오면 창 모두 닫기
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }

        void PracticeVector()
        {
            Vec4d vector1 = new Vec4d(1.0, 2.0, 3.0, 4.0);
            Vec4d vector2 = new Vec4d(1.0, 2.0, 3.0, 4.0);

            vectorText.Text = "";
            vectorText.Text += vector1.Item0.ToString() + "\r\n";
            vectorText.Text += vector1[1].ToString() + "\r\n";
            vectorText.Text += vector1.Equals(vector2).ToString() + "\r\n";
            vectorText.Text += "\r\n";
        }

        void PracticePoint()
        {
            Vec3d vector = new Vec3d(1.0, 2.0, 3.0);
            Point3d pt1 = new Point3d(1.0, 2.0, 3.0);
            Point3d pt2 = vector;

            vectorText.Text += pt1.ToString() + "\r\n";
            vectorText.Text += pt2.ToString() + "\r\n";
            vectorText.Text += pt1.X.ToString() + "\r\n";
            vectorText.Text += "\r\n";
        }

        void PracticeScalar()
        {
            Scalar s1 = new Scalar(252, 427);
            Scalar s2 = Scalar.Yellow;
            Scalar s3 = Scalar.All(99);

            vectorText.Text += s1.ToString() + "\r\n";
            vectorText.Text += s2.ToString() + "\r\n";
            vectorText.Text += s3.ToString() + "\r\n";
            vectorText.Text += "\r\n";
        }

        void PracticeRect()
        {
            OpenCvSharp.Rect rect1 = new OpenCvSharp.Rect(new OpenCvSharp.Point(0, 0), new OpenCvSharp.Size(640, 480));
            OpenCvSharp.Rect rect2 = new OpenCvSharp.Rect(10, 10, 640, 480);

            vectorText.Text = rect1.ToString() +"\r\n";
            vectorText.Text += rect2.ToString() + "\r\n";
        }

        void PracticeMatrix()
        {
            // 640x480 크기 3ch(채널) 행렬
            Mat m1 = new Mat(480, 640, MatType.CV_8UC3);
            Mat m2 = new Mat(new OpenCvSharp.Size(640, 480), MatType.CV_8UC3);

            Mat m = new Mat();

            m.Create(MatType.CV_8UC3, new int[] { 640, 480 });
            //m.Create(new OpenCvSharp.Size(640, 480), MatType.CV_8UC3);
            //m.Create(480, 640, MatType.CV_8UC3);


            // (255, 0, 0)으로 행렬의 모든 요소 초기화
            m.SetTo(new Scalar(255, 0, 0));
        }
    }
}