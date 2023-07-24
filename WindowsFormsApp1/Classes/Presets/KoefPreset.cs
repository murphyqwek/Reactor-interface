using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes
{
    public class KoefPreset
    {
        public enum Type
        {
            Tigel = 0,
            Voilok = 1
        }

        public List<double[]> TigelKoeffs { get; private set; }
        public List<double[]> VoilokKoeffs { get; private set; }
        /*
            Contact;
            AnodUp;
            AnodDown;
            Time;
        */
        public string Name { get; private set; }

        public KoefPreset(List<double[]> tigelKoeffs, List<double[]> voilokKoefs, string name)
        {
            TigelKoeffs = tigelKoeffs;
            VoilokKoeffs = voilokKoefs;

            Name = name;
        }

        public string getWorkModeTypeKoeff(int workMode, Type type)
        {
            List<double[]> koeffs = type == Type.Tigel ? TigelKoeffs : VoilokKoeffs;

            return string.Format("Контакт: {0}, Анод вверх: {1}\nВремя: {2}, Анод вниз {3}", koeffs[workMode][0], koeffs[workMode][1],
                                                                          koeffs[workMode][2], koeffs[workMode][3]);
        }

        /*
        public string getPresetToolTipText()
        {
            string text = "";

            for (Type type = 0; type < Type.Voilok; type++)
            {
                for(int i = 0; i < 4; i++)
                    text += (i * 50 + 50).ToString() + "A:\n" + getWorkModeTypeKoeff(i, type) + "\n";
                text += "\n";
            }
            return text;
        }
        */
        public void ChangeKoeffsList(List<double[]> newKoeffs, Type type)
        {
            if (type == Type.Tigel)
                TigelKoeffs = newKoeffs;
            else
                VoilokKoeffs = newKoeffs;
        }
    }
}