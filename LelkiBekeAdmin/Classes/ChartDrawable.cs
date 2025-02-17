using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Classes
{
    public class ChartDrawable : IDrawable
    {
        private ObservableCollection<StatModel> _salesData;

        // Constructor to accept data
        public ChartDrawable(ObservableCollection<StatModel> salesData)
        {
            _salesData = salesData;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float maxHeight = 250;
            float padding = 30;
            float barWidth = 40;
            int maxValue = _salesData.Max(s => s.Value);
            float scaleFactor = maxHeight / maxValue;
            float xPosition = padding;
            foreach (var stat in _salesData)
            {
                float barHeight = stat.Value * scaleFactor;
                canvas.FillColor = Colors.GreenYellow;
                canvas.FillRectangle(xPosition, maxHeight - barHeight, barWidth, barHeight);
                canvas.FillColor = Colors.Black;
                canvas.DrawString(stat.Category, xPosition + (barWidth / 2) - 15, maxHeight + 10, barWidth, 20, HorizontalAlignment.Left, VerticalAlignment.Top);
                xPosition += barWidth + 10;
            }
        }
    }
}
