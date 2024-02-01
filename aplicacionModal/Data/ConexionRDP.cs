using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplicacionModal.Data
{
    public class ConexionRDP
    {
     
      

        public static void Conexion(int logonEventId, int logoffEventId)
        {
             string rdpLogName = "Microsoft-Windows-TerminalServices-LocalSessionManager/Operational";
            // se crea un objeto para leer eventos de registro 
            EventLogQuery query = new EventLogQuery(rdpLogName, PathType.LogName, "*[System/EventID=" + logonEventId + " or System/EventID=" + logoffEventId + "]");
            EventLogReader logReader = new EventLogReader(query);
            // escucha los eventos
            for (EventRecord eventInstance = logReader.ReadEvent(); eventInstance != null; eventInstance = logReader.ReadEvent())
            {
                int eventId = (int)eventInstance.Id;

                if (eventId == logonEventId)
                {
                    MessageBox.Show("Usuario conectado: " + eventInstance.Properties[0].Value);

                }
                else if (eventId == logoffEventId)
                {
                    MessageBox.Show("Usuario desconectado: " + eventInstance.Properties[0].Value);
                }
                break;
            }

        }
    }
}
