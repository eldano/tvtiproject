using System;

using System.Threading;

namespace TVTIProject
{
    public class Song 
    {

        private static Thread music { get; set; }
        private static string songName { get; set; }
        private static Microsoft.DirectX.AudioVideoPlayback.Audio soundFile { get; set; }

        private static System.Timers.Timer timer = new System.Timers.Timer();

        public Song()
        {

        }

        public static void PlaySong(string s)
        {
            songName = s;
            ThreadStart funcionStart = new ThreadStart(PlaySongFunc);
            if(music != null && music.IsAlive){
                timer.Stop();
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

            soundFile = new Microsoft.DirectX.AudioVideoPlayback.Audio(fileName);
            soundFile.Play();
            
            
            timer.Elapsed += new System.Timers.ElapsedEventHandler(soundFile_Ending);
            timer.Interval = soundFile.Duration * 1000;
            timer.Start();
        
            
        }

        static void soundFile_Ending(object sender, EventArgs e)
        {
            soundFile.CurrentPosition = 0;
        }

       

    }
}
