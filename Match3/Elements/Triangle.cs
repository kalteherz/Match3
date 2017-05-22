/*
 * Author: Bolotin S.E.
 */

using System;
using System.Drawing;

namespace Match3
{
	public class Triangle: Elem {
		protected override void DrawShape(Graphics canvas) {
			Rectangle rect = Rect();
			canvas.FillPolygon(new SolidBrush(Color.Indigo),
				new PointF[3] { new PointF(rect.Left, rect.Bottom), 
			    				new PointF(rect.Right, rect.Bottom), 
			    				new PointF(rect.X + rect.Width / 2, rect.Top)});
		}
	}
}
