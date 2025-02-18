using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Classes
{
    public class QRCodeDrawable : IDrawable
    {
        public string Text { get; set; }

        public QRCodeDrawable(string text)
        {
            Text = text;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FillColor = Colors.White;
            canvas.FillRectangle(dirtyRect);

            if (string.IsNullOrWhiteSpace(Text))
                return;

            canvas.FillColor = Colors.Black;

            // Fake QR Code Generation: Alternating Squares
            int size = 20;
            Random random = new Random(Text.GetHashCode());

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (random.Next(2) == 1)
                    {
                        canvas.FillRectangle(x * size, y * size, size, size);
                    }
                }
            }
        }
    }
}
