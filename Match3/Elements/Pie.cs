/*
 * Author: Bolotin S.E.
 */

using System;
using System.Drawing;

namespace Match3
{
	public class Pie : Elem {
		protected override void DrawShape(Graphics canvas) {
			Rectangle rect = Rect();
			rect.Height *= 2;
			canvas.FillPie(new SolidBrush(Color.Orange), rect, 240, 60);
		}
	}
}
