using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        public static string CarNameInvalid = "Araç ismi geçersiz";
        public static string CarSuccessfullAdded = "Araç başarıyla eklendi";
        public static string CarNotSuccessfullAdded = "Araç  eklenemedi";
        public static string CarImageCount = "aynı araca ait en fazla 5 resim olmalıdır";
        public static string CarImageFolderImageAdded="araba resmi dosyaya eklendi";
        internal static SerializationInfo AuthorizationDenied;
    }
}
