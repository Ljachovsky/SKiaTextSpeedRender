using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace snake
{
    public enum type
    {
        none,
        body,
        head,
        apple
    }

    public enum vector
    {
        up,
        right,
        down,
        left
    }
    public class FieldElement
    {
        
        public type Type { get; set; }
        public vector Vector { get; set; } // if Type is 'head'
        public int Age { get; set; } // if Type is 'body' or 'head'
        /*public Brushes GetColor()
        {

        }*/
        public FieldElement()
        {
            this.Type = type.none;
        }

    }
    public partial class MainPage : ContentPage
    {
        SKCanvasView canvasView = new SKCanvasView();
        Random rand = new Random();
        FieldElement[,] LogicField = new FieldElement[40, 30];
        BoxView[,] RectangleField = new BoxView[40, 30];
        public MainPage()
        {
            InitializeComponent();

            GenerateField();
            // field.HeightRequest = Device.Info.PixelScreenSize.Width*(30.0/40.0);

            //Content = field;


            /////

            SimpleCirclePage();
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), OnTimerTick);
            Device.StartTimer(TimeSpan.FromMilliseconds(0), OnTimerTick2);
        }

        void GenerateField()
        {
            
            /////

            for (int i = 0; i < LogicField.GetUpperBound(0) + 1; i++)
                for (int i_ = 0; i_ < LogicField.Length / (LogicField.GetUpperBound(0) + 1); i_++)
                {
                    BoxView rect = new BoxView();
                    rect.Background = new SolidColorBrush(Color.FromRgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)));
                    RectangleField[i, i_] = rect;
                    LogicField[i, i_] = new FieldElement();

                    AbsoluteLayout.SetLayoutBounds(rect, new Xamarin.Forms.Rectangle((double)i / 39.0, (double)i_ / 29.0, 10, 10));
                    AbsoluteLayout.SetLayoutFlags(rect, AbsoluteLayoutFlags.PositionProportional);

                    //field.HeightRequest = 
                    field.Children.Add(rect);
                }
        }

        void RenderField()
        {
            if (chckbx.IsChecked)
            Task.Run(async () =>
            {
                for (int i = 0; i < LogicField.GetUpperBound(0) + 1; i++)
                    for (int i_ = 0; i_ < LogicField.Length / (LogicField.GetUpperBound(0) + 1); i_++)
                    {
                        //BoxView rect = new BoxView();
                        // rect.Background = ;
                        RectangleField[i, i_].Background = new SolidColorBrush(Color.FromRgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)));
                        // LogicField[i, i_] = new FieldElement();

                        //AbsoluteLayout.SetLayoutBounds(rect, new Xamarin.Forms.Rectangle((double)i / 40.0, (double)i_ / 30.0, 10, 10));
                        // AbsoluteLayout.SetLayoutFlags(rect, AbsoluteLayoutFlags.PositionProportional);

                        //field.HeightRequest = 
                        //  field.Children.Add(rect);
                    }
            }
            ).Wait();

           
        }
        private bool OnTimerTick()
        {
            //await RenderField();
            Task.Run(()=> RenderField() );
            
            return true;
        }

        private bool OnTimerTick2()
        {
            canvasView.InvalidateSurface();
            return true;
        }
        void SimpleCirclePage()
        {
            Title = "Simple Circle";
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            canvasView.HeightRequest = 267;
            canvasView.WidthRequest = 350;
            canvasView.VerticalOptions =LayoutOptions.Center;
            canvasView.HorizontalOptions = LayoutOptions.Center;
            stack.Children.Add(canvasView);
            
        }
        void RePaint(SKCanvas canvas)
        {
           /* canvas.Clear();
            canvas.DrawColor(Color.DarkGray.ToSKColor());
            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = rand.Next(40, 200)
            };
            canvas.DrawCircle(canvas.ar .Width / 2, info.Height / 2, 100, paint);

            paint.Style = SKPaintStyle.Fill;
            paint.Color = SKColors.Blue;
            canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);

            canvas.DrawText("РАДУГА", 20.0f, 64.0f, new SKPaint
            {
                TextSize = 64.0f,
                IsAntialias = true,
                Color = new SKColor(0, 136, 0),
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 3
            });*/
        }
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            canvas.DrawColor(Color.DarkGray.ToSKColor());




          /*  
            canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);

            paint.Style = SKPaintStyle.Fill;
            paint.Color = SKColors.Blue;
            canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);*/



            for (int i = 0; i < LogicField.GetUpperBound(0) + 1; i++)
                for (int i_ = 0; i_ < LogicField.Length / (LogicField.GetUpperBound(0) + 1); i_++)
                {
                    SKPaint paint = new SKPaint
                    {
                        Color = Color.FromRgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)).ToSKColor(),
                
                    };
                   // RectangleField[i, i_].Background = new SolidColorBrush(Color.FromRgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)));
                    
                    canvas.DrawRect((float)i*(350/40.0f)*2.7f, (float)i_*(267/30.0f) *2.7f, (350/44.0f) * 2.7f, (350/40.0f) * 2.7f, paint);
                }

        }
    }
}
