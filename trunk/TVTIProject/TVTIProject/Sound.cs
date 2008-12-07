using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TVTIProject
{
    class Sound
    {

        private Thread thread { set; get; }
        
        private static string soundId { get; set; }
        

        private static Microsoft.DirectX.AudioVideoPlayback.Audio soundAlcantarilla = new Microsoft.DirectX.AudioVideoPlayback.Audio("Resources\\Sonidos\\Alcantarilla.mp3");
  /*      private static Microsoft.DirectX.AudioVideoPlayback.Audio soundAceite = new Microsoft.DirectX.AudioVideoPlayback.Audio("Resources\\Sonidos\\Aceite.mp3");
        private static Microsoft.DirectX.AudioVideoPlayback.Audio soundBasura = new Microsoft.DirectX.AudioVideoPlayback.Audio("Resources\\Sonidos\\Basura.mp3");
        private static Microsoft.DirectX.AudioVideoPlayback.Audio soundEspatula = new Microsoft.DirectX.AudioVideoPlayback.Audio("Resources\\Sonidos\\Espatula.mp3");
        private static Microsoft.DirectX.AudioVideoPlayback.Audio soundExtinguidor = new Microsoft.DirectX.AudioVideoPlayback.Audio("Resources\\Sonidos\\Extinguidor.mp3");
        private static Microsoft.DirectX.AudioVideoPlayback.Audio soundMorirPozo = new Microsoft.DirectX.AudioVideoPlayback.Audio("Resources\\Sonidos\\Morir.mp3");
        private static Microsoft.DirectX.AudioVideoPlayback.Audio soundMorirAceite = new Microsoft.DirectX.AudioVideoPlayback.Audio("Resources\\Sonidos\\Morir.mp3");
        private static Microsoft.DirectX.AudioVideoPlayback.Audio soundMorirBasura = new Microsoft.DirectX.AudioVideoPlayback.Audio("Resources\\Sonidos\\Morir.mp3");
        private static Microsoft.DirectX.AudioVideoPlayback.Audio soundMorirCalle = new Microsoft.DirectX.AudioVideoPlayback.Audio("Resources\\Sonidos\\Morir.mp3");
        private static Microsoft.DirectX.AudioVideoPlayback.Audio soundMorirFuego = new Microsoft.DirectX.AudioVideoPlayback.Audio("Resources\\Sonidos\\Morir.mp3");
        */

        public Sound()
        {

        }

        public static  void init(){
            //DO NOTHING JUST FOR C# LOADING
        }

        public static void PlaySound(string s)
        {
            soundId = s;
            Sound threadito = new Sound();
            ThreadStart funcionStart = new ThreadStart(threadito.PlaySoundFunc);
            Thread music = new Thread(funcionStart);
            threadito.thread = music;
            music.Start();
            

        }


        public void PlaySoundFunc()
        {
           Microsoft.DirectX.AudioVideoPlayback.Audio soundFile= null;
            
            //Elijo el sonido que tengo que reproducir...
            if (soundId == "alcantarilla")
            {
                soundFile = soundAlcantarilla;
            }
           /* else if (soundId == "aceite")
            {
                soundFile = soundAceite;
            }
            else if (soundId == "basura")
            {
                soundFile = soundBasura;
            }
            else if (soundId == "espatula")
            {
                soundFile = soundEspatula;
            }
            else if (soundId == "extinguidor")
            {
                soundFile = soundExtinguidor;
            }
            else if (soundId == "morirpozo")
            {
                soundFile = soundMorirPozo;
            }
            else if (soundId == "moriraceite")
            {
                soundFile = soundMorirAceite;
            }
            else if (soundId == "morirbasura")
            {
                soundFile = soundMorirBasura;
            }
            else if (soundId == "morircalle")
            {
                soundFile = soundMorirCalle;
            }
            else if (soundId == "morirfuego")
            {
                soundFile = soundMorirFuego;
            }*/
            

            //Si es un sonido válido lo reproduzco
            if (soundFile != null)
            {
                //Estaba bien el parámetro

                //Si el sonido se estaba reproduciendo lo reseteo...
                soundFile.CurrentPosition = 0;
                soundFile.Play();
                //Espero a que termine el sonido para morirme
                Thread.Sleep(Convert.ToInt32(soundFile.Duration) * 1000 + 100);
             
            }

            //termino el thread
            thread.Abort();
        }



       
    }
}
