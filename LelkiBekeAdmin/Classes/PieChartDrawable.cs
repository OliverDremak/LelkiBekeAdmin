using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LelkiBekeAdmin.Classes
{
    class PieChartDrawable : IDrawable
    {
        private readonly ObservableCollection<StatModel> _salesData;
        private const float Padding = 40;
        private readonly Color[] _colors = new Color[]
        {
                Colors.Red, Colors.Green, Colors.Blue, Colors.Orange, Colors.Purple, Colors.Cyan,
                Colors.Magenta, Colors.Yellow, Colors.Brown, Colors.Gray, Colors.Pink, Colors.Teal
        };

        public PieChartDrawable(ObservableCollection<StatModel> salesData)
        {
            _salesData = salesData;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (_salesData == null || !_salesData.Any())
                return;

            // Calculate the pie chart's size and center
            float pieRadius = Math.Min(dirtyRect.Width, dirtyRect.Height) / 2 - Padding;
            float centerX = dirtyRect.Width / 2;
            float centerY = dirtyRect.Height / 2;

            // Calculate total value
            float total = _salesData.Sum(s => s.Value);
            if (total <= 0) return;

            float currentAngle = 0;

            // Draw pie slices
            for (int i = 0; i < _salesData.Count; i++)
            {
                var stat = _salesData[i];
                if (stat.Value <= 0) continue;

                float sweepAngle = (stat.Value / total) * 360;

                canvas.StrokeColor = Colors.White;
                canvas.StrokeSize = 1;
                canvas.FillColor = _colors[i % _colors.Length];

                // Draw the slice
                DrawPieSlice(canvas, centerX, centerY, pieRadius, currentAngle, currentAngle + sweepAngle);

                currentAngle += sweepAngle;
            }

            // Draw legend
            float legendX = dirtyRect.Width - 200; // Move legend to right side
            float legendY = Padding;

            canvas.FontSize = 14;
            foreach (var stat in _salesData.Select((value, index) => new { value, index }))
            {
                if (stat.value.Value <= 0) continue;

                // Color square
                canvas.FillColor = _colors[stat.index % _colors.Length];
                canvas.FillRectangle(legendX, legendY, 20, 20);

                // Legend text
                canvas.FontColor = Colors.Black;
                string percentage = $"{(stat.value.Value / total * 100):0.#}%";
                canvas.DrawString($"{stat.value.Category} - {percentage}",
                    legendX + 25, legendY, 200, 20,
                    HorizontalAlignment.Left,
                    VerticalAlignment.Center);

                legendY += 25;
            }
        }

        private void DrawPieSlice(ICanvas canvas, float centerX, float centerY, float radius, float startAngle, float endAngle)
        {
            PathF path = new PathF();
            path.MoveTo(centerX, centerY);
            path.LineTo(centerX + radius * (float)Math.Cos(Math.PI * startAngle / 180), centerY + radius * (float)Math.Sin(Math.PI * startAngle / 180));
            path.AddArc(centerX - radius, centerY - radius, centerX + radius, centerY + radius, startAngle, endAngle, true);
            path.Close();

            canvas.FillPath(path, WindingMode.NonZero);
            canvas.DrawPath(path);
        }
    }
}
