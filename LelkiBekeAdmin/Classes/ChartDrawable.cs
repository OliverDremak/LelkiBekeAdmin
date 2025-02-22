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
        private readonly ObservableCollection<StatModel> _salesData;
        private const float Padding = 40;
        private const float BarSpacing = 10;
        private int NumberOfTicks = 5;
        public ChartDrawable(ObservableCollection<StatModel> salesData)
        {
            _salesData = salesData;

        }
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (_salesData == null || !_salesData.Any())
                return;
            float chartWidth = dirtyRect.Width - (Padding * 2);
            float chartHeight = dirtyRect.Height - (Padding * 2);
            float maxValue = _salesData.Max(s => s.Value);
            float scaleFactor = chartHeight / maxValue;
            float barWidth = (chartWidth / _salesData.Count) - BarSpacing;
            float xAxisY = dirtyRect.Height - Padding; 
            float yAxisX = Padding;                    
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 2;
            canvas.DrawLine(yAxisX, xAxisY, dirtyRect.Width - Padding, xAxisY);
            canvas.DrawLine(yAxisX, Padding, yAxisX, xAxisY);
            canvas.FontColor = Colors.Black;
            canvas.FontSize = 14;
            canvas.StrokeColor = Colors.LightGray;
            canvas.StrokeSize = 1;
            for (int i = 0; i <= NumberOfTicks; i++)
            {
                float currentValue = i * (maxValue / NumberOfTicks);
                float tickY = xAxisY - (currentValue * scaleFactor);
                canvas.DrawLine(yAxisX, tickY, dirtyRect.Width - Padding, tickY);
                canvas.FontColor = Colors.Black; 
                canvas.DrawString(
                    currentValue.ToString("0"),
                    x: yAxisX - 5,
                    y: tickY,
                    horizontalAlignment: HorizontalAlignment.Right
                );
            }
            float xPosition = Padding + (BarSpacing / 2);
            canvas.FontSize = 14;
            foreach (var stat in _salesData)
            {
                float barHeight = stat.Value * scaleFactor;
                float yPosition = xAxisY - barHeight;
                canvas.FillColor = Colors.LimeGreen;
                canvas.FillRectangle(xPosition, yPosition, barWidth, barHeight);
                canvas.FontColor = Colors.Black;
                string categoryLabel = stat.Category;
                if (_salesData.Count > 7)
                {
                    categoryLabel = stat.Category.Substring(0, 1);
                }
                canvas.DrawString(
                    categoryLabel,
                    x: xPosition + (barWidth / 2),
                    y: xAxisY + 5,
                    horizontalAlignment: HorizontalAlignment.Center
                );
                xPosition += barWidth + BarSpacing;
            }
        }
    }
}
