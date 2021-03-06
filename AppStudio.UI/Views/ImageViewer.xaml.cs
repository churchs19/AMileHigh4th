using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;

using Microsoft.Phone.Controls;

namespace AppStudio
{
    public partial class ImageViewer : PhoneApplicationPage
    {
        const double MAX_SCALE = 10;

        private double _scale = 1.0;
        private double _minScale;
        private double _coercedScale;
        private double _originalScale;

        private Size viewportSize;
        private Point _screenMidpoint;
        private Point _relativeMidpoint;

        private bool _pinching;

        private BitmapImage _bitmap;

        public ImageViewer()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey("url"))
            {
                SetImageSource(this.NavigationContext.QueryString["url"]);
            }
            base.OnNavigatedTo(e);
        }

        private void SetImageSource(string imageSource)
        {
            if (!String.IsNullOrEmpty(imageSource))
            {
                Uri uri = null;
                if (imageSource.StartsWith("/"))
                {
                    uri = new Uri(imageSource, UriKind.Relative);
                }
                else
                {
                    uri = new Uri(imageSource, UriKind.RelativeOrAbsolute);
                }

                image.Source = new BitmapImage(uri)
                {
                    CreateOptions = BitmapCreateOptions.DelayCreation,
                    DecodePixelHeight = 800
                };

                Dispatcher.BeginInvoke(() =>
                {
                    SetInitialScale();
                });
            }
        }

        /// <summary> 
        /// When a new image is opened, set its initial scale. 
        /// </summary> 
        private void OnImageOpened(object sender, RoutedEventArgs e)
        {
            SetInitialScale();
        }

        private void SetInitialScale()
        {
            _bitmap = (BitmapImage)image.Source;

            // Set scale to the minimum, and then save it. 
            _scale = 0;
            CoerceScale(true);
            _scale = _coercedScale;

            ResizeImage(true);

            image.Opacity = 1.0;
        }

        /// <summary> 
        /// Handler for the ManipulationStarted event. Set initial state in case 
        /// it becomes a pinch later. 
        /// </summary> 
        private void OnManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            _pinching = false;
            _originalScale = _scale;
        }

        /// <summary> 
        /// Handler for the ManipulationDelta event. It may or may not be a pinch. If it is not a  
        /// pinch, the ViewportControl will take care of it. 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void OnManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            if (e.PinchManipulation != null)
            {
                e.Handled = true;

                if (!_pinching)
                {
                    _pinching = true;
                    Point center = e.PinchManipulation.Original.Center;
                    _relativeMidpoint = new Point(center.X / image.ActualWidth, center.Y / image.ActualHeight);

                    var xform = image.TransformToVisual(viewport);
                    _screenMidpoint = xform.Transform(center);
                }

                _scale = _originalScale * e.PinchManipulation.CumulativeScale;

                CoerceScale(false);
                ResizeImage(false);
            }
            else if (_pinching)
            {
                _pinching = false;
                _originalScale = _scale = _coercedScale;
            }
        }

        /// <summary> 
        /// The manipulation has completed (no touch points anymore) so reset state. 
        /// </summary> 
        private void OnManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            _pinching = false;
            _scale = _coercedScale;
        }

        /// <summary>
        /// Either the user has manipulated the image or the size of the viewport has changed. We only 
        /// care about the size. 
        /// </summary>
        private void OnViewportChanged(object sender, ViewportChangedEventArgs e)
        {
            Size newSize = new Size(viewport.Viewport.Width, viewport.Viewport.Height);
            if (newSize != viewportSize)
            {
                viewportSize = newSize;
                CoerceScale(true);
                ResizeImage(false);
            }
        }

        /// <summary> 
        /// Adjust the size of the image according to the coerced scale factor. Optionally 
        /// center the image, otherwise, try to keep the original midpoint of the pinch 
        /// in the same spot on the screen regardless of the scale. 
        /// </summary> 
        /// <param name="center"></param> 
        void ResizeImage(bool center)
        {
            if (_coercedScale != 0 && _bitmap != null)
            {
                double newWidth = canvas.Width = Math.Round(_bitmap.PixelWidth * _coercedScale);
                double newHeight = canvas.Height = Math.Round(_bitmap.PixelHeight * _coercedScale);

                transform.ScaleX = transform.ScaleY = _coercedScale;

                viewport.Bounds = new Rect(0, 0, newWidth, newHeight);

                if (center)
                {
                    viewport.SetViewportOrigin(
                        new Point(
                            Math.Round((newWidth - viewport.ActualWidth) / 2),
                            Math.Round((newHeight - viewport.ActualHeight) / 2)
                            ));
                }
                else
                {
                    Point newImgMid = new Point(newWidth * _relativeMidpoint.X, newHeight * _relativeMidpoint.Y);
                    Point origin = new Point(newImgMid.X - _screenMidpoint.X, newImgMid.Y - _screenMidpoint.Y);
                    viewport.SetViewportOrigin(origin);
                }
            }
        }

        /// <summary> 
        /// Coerce the scale into being within the proper range. Optionally compute the constraints  
        /// on the scale so that it will always fill the entire screen and will never get too big  
        /// to be contained in a hardware surface. 
        /// </summary> 
        /// <param name="recompute">Will recompute the min max scale if true.</param> 
        void CoerceScale(bool recompute)
        {
            if (recompute && _bitmap != null && viewport != null)
            {
                // Calculate the minimum scale to fit the viewport 
                double minX = viewport.ActualWidth / _bitmap.PixelWidth;
                double minY = viewport.ActualHeight / _bitmap.PixelHeight;

                _minScale = Math.Min(minX, minY);
            }

            _coercedScale = Math.Min(MAX_SCALE, Math.Max(_scale, _minScale));
        }
    }
}
