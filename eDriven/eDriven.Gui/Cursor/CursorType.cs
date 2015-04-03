#region License

/*
 
Copyright (c) 2010-2014 Danko Kozar

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
 
*/

#endregion License

namespace eDriven.Gui.Cursor
{
    public sealed class CursorType
    {
        public const string Normal = null;
        public const string Pointer = "pointer";
        public const string Crosshair = "crosshair";
        public const string Move = "move";
        public const string EResize = "e-resize";
        public const string WResize = "w-resize";
        public const string NResize = "n-resize";
        public const string SResize = "s-resize";
        public const string NeResize = "ne-resize";
        public const string NwResize = "nw-resize";
        public const string SeResize = "se-resize";
        public const string SwResize = "sw-resize";
        public const string Wait = "wait";
        public const string Progress = "progress";
        public const string AcceptDrop = "dd-accept";
        public const string RejectDrop = "dd-reject";
        public const string DragCopy = "dd-copy";
        public const string DragMove = "dd-move";
        public const string DragLink = "dd-link";
    }
}