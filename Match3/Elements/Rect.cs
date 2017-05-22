/*
 * Author: Bolotin S.E.
 */
 
using System;
using System.Drawing;

namespace Match3
{
	public class Rect: Elem {
		protected override void DrawShape(Graphics canvas) {
			canvas.FillRectangle(new SolidBrush(Color.Red), Rect());
		}
	}
}
