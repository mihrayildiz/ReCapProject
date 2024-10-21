using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Helper.GuidHelper;
using Core.Utilities.Helper.FileHelper.Constants;
using System.Threading.Tasks.Dataflow;




namespace Core.Utilities.Helper.FileHelper;

public class FileHelper : IFileHelper
{
    public string Add(IFormFile file)
    {
        string fileExtension = Path.GetExtension(file.FileName);  //dosyanın uzantısını aldım örnğin :jpg
        string uniqueFileName = GuidHelper.GuidHelper.Create() + fileExtension;  // unique değer ile birleştridim 

        var imagePath = FilePath.Full(uniqueFileName); //imagepathede bu uniq ismi atadım

        using FileStream fileStream = new(imagePath, FileMode.Create);

        file.CopyTo(fileStream);
        fileStream.Flush(); //arabelleği temizle
        return (uniqueFileName);
    }

    public void Delete(string path)
    {
        if (Path.Exists(FilePath.Full(path)))
        {
            File.Delete(FilePath.Full(path));
            
        }
        else
        {
            Console.WriteLine("dosya bulunamadı");
        }
    }

    public void Update(IFormFile file, string imagePath)
    {
        var fullPath = FilePath.Full(imagePath);

        if(Path.Exists(fullPath))  //gücellemek istediğim path var mı 
        {
            using FileStream fileStream =  new(fullPath, FileMode.Create); ///burada Create  üzerine yazma işlemi yapar
            file.CopyTo(fileStream);
            fileStream.Flush();
        }
        else
        {
          
        }

    }
}


// Path, .NET framework'ün sağladığı bir sınıftır dosya ve dizin adlarıyla ilgili çeşitli yardımcı metodlar sağlar.
// FilMode.Create
// İşletim sisteminin yeni bir dosya oluşturması gerektiğini 
// belirtir. Dosya zaten mevcutsa, üzerine yazılacaktır.