/*
 * Author: Bolotin S.E.
 */

using System;
using System.Drawing;

namespace Match3
{
	public class Rhombus: Elem {
		protected override void DrawShape(Graphics canvas) {
			Rectangle rect = Rect();
			canvas.FillPolygon(new SolidBrush(Color.Green),
				new PointF[4] { new PointF(rect.X + rect.Width / 2, rect.Top), 
			    				new PointF(rect.Right, rect.Y + rect.Height / 2), 
			    				new PointF(rect.X + rect.Width / 2, rect.Bottom),
			                    new PointF(rect.X, rect.Y + rect.Height / 2)});		}
	}
}
