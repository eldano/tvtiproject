using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SlimDX.XAudio2;
using System.Runtime.InteropServices;
using System.Threading;
using SlimDX.Multimedia;

namespace TVTIProject
{
    public class Song 
    {

        private static Thread music { get; set; }
        private static string songName { get; set; }
        private static AudioBuffer buffer { get; set; }
        private static SourceVoice sourceVoice { get; set; }

        public Song()
        {

        }

        public static void PlaySong(string s)
        {
            songName = s;
            ThreadStart funcionStart = new ThreadStart(PlaySongFunc);
            if(music != null && music.IsAlive){
                music.Abort();
            }
            music = new Thread(funcionStart);
            music.Start();

        }


        public static void PlaySongFunc()
        {
            string fileName = "";

            //dependiendo de lo que le pase como parámetro
            //elijo que canción voy a reproducir
            if (songName == "city")
            {
                fileName = "Resources\\City.wav"; 
            }

            
            SlimDX.XAudio2.XAudio2 device = new SlimDX.XAudio2.XAudio2();

            //Me inicializa el array de voces
            MasteringVoice masteringVoice = new MasteringVoice(device);

            byte[] data;
            WaveFormat format;
            // leo el archivo que quiero reproducir
            using (WaveFile file = new WaveFile(fileName))
            {
                format = file.Format;
                data = new byte[file.Size];
                file.Read(data, file.Size);
            }

            // si no pongo esto me da un error porque inicializa alguna estructura de la tarjeta de sonido
            sourceVoice = new SourceVoice(device, format);

            // creo el buffer que voy a reproducir
            buffer = new AudioBuffer();
            buffer.AudioData = data;
            buffer.AudioBytes = data.Length;

            //no se que hace
            buffer.Flags = BufferFlags.EndOfStream;

            //mando el buffer a la tarjeta de sonido para que después lo reproduzca
            sourceVoice.SubmitSourceBuffer(buffer);
            //otro buffer para que no se note nunca el salto
            sourceVoice.SubmitSourceBuffer(buffer);

            // arranca la canción
            sourceVoice.Start();

            //hacer que se quede cantando por mucho rato...
            sourceVoice.BufferEnd += new EventHandler<ContextEventArgs>(terminarBuffer);

            //Thread.Sleep(10);
            
        }


        public static void terminarBuffer(object sender, ContextEventArgs args)
        {
            sourceVoice.SubmitSourceBuffer(buffer);
        }

    }
}
