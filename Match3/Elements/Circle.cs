/*
 * Author: Bolotin S.E.
 */

using System;
using System.Drawing;

namespace Match3
{
	public class Circle: Elem {
		protected override void DrawShape(Graphics canvas) {
			canvas.FillEllipse(new SolidBrush(Color.Blue), Rect());
		}
	}
}
