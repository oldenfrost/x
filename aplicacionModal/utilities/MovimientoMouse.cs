using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplicacionModal.utilitis
{
    public class MovimientoMouse
    {
        /************************************************************************/
        /*****************************import************************************/
        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool ClipCursor(ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        // estrucutra para medir la dimension de  la pantalla
        public struct RECT
        {
            public int Izquierda;
            public int Arriba;
            public int Derecha;
            public int Abajo;
        }
        // metodo estatico 
        public static void BloqueoMouse(Form formulario)
        {
            RECT formRect = new RECT();
            GetClientRect(formulario.Handle, out formRect);
            Point formTopLeft = formulario.PointToScreen(new Point(formRect.Izquierda, formRect.Arriba));
            Point formBottomRight = formulario.PointToScreen(new Point(formRect.Derecha, formRect.Abajo));
            RECT clipRect = new RECT
            {
                Izquierda = formTopLeft.X,
                Arriba = formTopLeft.Y+4,
                Derecha = formBottomRight.X-10,
                Abajo = formBottomRight.Y-16
            };
            ClipCursor(ref clipRect);
        }
     
    }
}
