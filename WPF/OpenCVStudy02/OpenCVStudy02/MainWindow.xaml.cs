using OpenCvSharp;

namespace OpenCVStudy02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        Mat src, frame;

        readonly string cvWindow = "White board";
        readonly string videoFileName = "coding_on.mp4";
        readonly string camView = "Camera view";

        public MainWindow()
        {
            InitializeComponent();

            //DrawBoard();
            //PlayVideo();

            frame = new Mat();
            
            //CamCapture();
            CamCapturePractice();
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

        void CamCapturePractice()
        {
            VideoCapture capture = new VideoCapture(0);

            capture.Set(VideoCaptureProperties.FrameWidth, 640);
            capture.Set(VideoCaptureProperties.FrameHeight, 480);

            capture.Read(frame);
            Cv2.ImShow(camView, frame);

            MouseCallback cvMouseCallback = new MouseCallback(CursurLocDraw);
            Cv2.SetMouseCallback(camView, cvMouseCallback, frame.CvPtr);

            while (true)
            {
                if (capture.IsOpened())
                {
                    capture.Read(frame);
                    Cv2.ImShow(camView, frame);

                    if (Cv2.WaitKey(33) == 'q')
                        break;
                }
            }

            capture.Release();
            Cv2.DestroyAllWindows();
        }

        void CursurLocDraw(MouseEventTypes @event, int x, int y, MouseEventFlags flags, IntPtr userdate)
        {
            if (flags == MouseEventFlags.LButton)
            {
                Cv2.Circle(frame, new Point(x, y), 5, Scalar.Red, -1);
                Cv2.ImShow(camView, frame);
            }
        }
    }
}