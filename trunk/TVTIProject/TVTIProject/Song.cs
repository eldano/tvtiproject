using System;

using System.Threading;

namespace TVTIProject
{
    public class Song 
    {

        private static Thread music { get; set; }
        private static string songName { get; set; }

        //Una variable por canción para ahorrarnos el tiempo de carga de los mp3.
        private static Microsoft.DirectX.AudioVideoPlayback.Audio ciudad= new Microsoft.DirectX.AudioVideoPlayback.Audio("Resources\\Musica\\ciudad.mp3");//{get;set;}
        private static Microsoft.DirectX.AudioVideoPlayback.Audio menu = new Microsoft.DirectX.AudioVideoPlayback.Audio("Resources\\Musica\\menu.mp3");//{get;set;}

        //canción actual
        private static Microsoft.DirectX.AudioVideoPlayback.Audio soundFile { set; get; }
        
        //timer utilizado para el loop
        private static System.Timers.Timer timer = new System.Timers.Timer();

        public Song()
        {

        }

        public static void init()
        {
            //Do nothing just for C# inicialization
        }

        //Abre el thread de reproducción de la canción
        public static void PlaySong(string s)
        {
            songName = s;
            ThreadStart funcionStart = new ThreadStart(PlaySongFunc);
            if(music != null && music.IsAlive){
                //Si había una canción la mato
                timer.Stop();
                music.Abort();
            }
            //Arranco el thread de la canción
            music = new Thread(funcionStart);
            music.Start();

        }


        //Thread para reproducir la canción
        public static void PlaySongFunc()
        {
            soundFile = null;


            //dependiendo de lo que le pase como parámetro
            //elijo que canción voy a reproducir
            if (songName == "ciudad")
            {
                soundFile = ciudad;
            }
            else if (songName == "menu")
            {
                soundFile = menu;
            }


            //Si era una canción válida la reproduzco
            if (soundFile != null)
            {
                soundFile.Play();
                timer.Elapsed += new System.Timers.ElapsedEventHandler(soundFile_Ending);
                timer.Interval = soundFile.Duration * 1000;
                timer.Start();
            }
            else
            {
                music.Abort();
            }
        
            
        }


        //Evento invocado por el timer cuando acaba la canción para poder hacer loop
        static void soundFile_Ending(object sender, EventArgs e)
        {
            soundFile.CurrentPosition = 0;
        }

       

    }
}
