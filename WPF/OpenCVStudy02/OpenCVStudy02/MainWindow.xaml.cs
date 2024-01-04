using OpenCvSharp;
using System.Diagnostics;

namespace OpenCVStudy02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        Mat src;

        readonly string cvWindow = "White board";
        readonly string videoFileName = "coding_on.mp4";

        public MainWindow()
        {
            InitializeComponent();

            //DrawBoard();
            //PlayVideo();
            CamCapture();
        }

        #region 그리기

        void DrawBoard()
        {
            src = new Mat(new Size(500, 500), MatType.CV_8UC3, new Scalar(255, 255, 255));

            Cv2.ImShow(cvWindow, src);

            MouseCallback cvMouseCallback = new MouseCallback(DragDraw);
            Cv2.SetMouseCallback(cvWindow, cvMouseCallback, src.CvPtr);

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }

        void DragDraw(MouseEventTypes @event, int x, int y, MouseEventFlags flags, IntPtr userdate)
        {
            if(flags == MouseEventFlags.LButton)
            {
                //Debug.WriteLine($"x={x}, y={y}");
                Cv2.Circle(src, x, y, 5, Scalar.Yellow, 10);
                //Cv2.Circle(src, new Point(x, y), 5, Scalar.Blue, -1);
                Cv2.ImShow(cvWindow, src);
            }
        }

        #endregion

        void PlayVideo()
        {
            VideoCapture capture = new VideoCapture(videoFileName);
            Mat frame = new Mat();

            while(true)
            {
                if (capture.PosFrames == capture.FrameCount) 
                    capture.Open(videoFileName);

                capture.Read(frame);
                Cv2.ImShow(videoFileName, frame);

                if (Cv2.WaitKey(33) == 'q')
                    break;
            }

            // 메모리 비우기
            capture.Release();
            Cv2.DestroyAllWindows();
        }

        void CamCapture()
        {
            VideoCapture capture = new VideoCapture(0);
            Mat frame = new Mat();

            capture.Set(VideoCaptureProperties.FrameWidth, 640);
            capture.Set(VideoCaptureProperties.FrameHeight, 480);

            while(true)
            {
                if(capture.IsOpened())
                {
                    capture.Read(frame);
                    Cv2.ImShow("Camera view", frame);

                    if (Cv2.WaitKey(33) == 'q')
                        break;
                }
            }

            capture.Release();
            Cv2.DestroyAllWindows();
        }
    }
}