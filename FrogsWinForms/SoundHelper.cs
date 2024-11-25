using System.Media;

namespace FrogsWinForms
{
    public static class SoundHelper
    {
        public static void Play(string path)
        {
            SoundPlayer player = new SoundPlayer(path);
            player.Play();
        }
    }
}
