namespace DataAccess
{
    //Single Respoinsibility ye gore...her bir gorev icin farkli class olusturmamiz gerekiyor...ondan dolayi yukarda bircok farkli gorev 1 class icinde toplanmis o zaman her bir ayri gorev icin bir class olusturalim..



    class NamesFilePathBuilder
    {
        public string BuildFilePath()
        {
            return "names.txt";
        }
    }
}
